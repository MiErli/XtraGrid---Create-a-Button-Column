using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ProjectHelper
{
	  public class Record
	{
		public int Id { get; set; }
		public int IdRandom { get; set; }
		public  bool Check { get; set; }
		public Image RandomImage { get; set; }
		public string Text { get; set; }
		public DateTime Date { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}

	public class DataHelper 
	{
		public DataHelper()
		{
			recordBindingList = new BindingList<Record>();
			AddDataToSource(20);
		}

		private GridControl _TargetControl;
		private BindingList<Record> recordBindingList;

		public GridControl TargetControl
		{
			get
			{
				return _TargetControl;
			}
			set
			{
				_TargetControl = value;
				ResetDataSource();
			}
		}

		public BindingList<Record> RecordBindingList
		{
			get
			{
				return recordBindingList;
			}
			set
			{
				recordBindingList = value;
				ResetDataSource();
			}
		}

		private void ResetDataSource()
		{
			if(_TargetControl == null) return;
			_TargetControl.DataSource = recordBindingList;
		}

		public void AddDataToSource(object count)
		{
			AddDataToSource(Convert.ToInt32(count));
		}

		  public void AddDataToSource(int count)
		{
			Random r = new Random();
			for (int i = 0; i < count; i++)
				recordBindingList.Add(new Record()
				{
					Id = recordBindingList.Count,
					Text = GetRandomString(r),
					Date = DateTime.Now + new TimeSpan(i, i, i, i),
					Check = r.Next(1,count) % 2 == 0,
					RandomImage = GetRandomImage(50,50,r),
					IdRandom = r.Next(0, count)
				});
		}

		public Image GetRandomImage(int w, int h, Random r)
		{
		   
			Color randomColor = GetRandomColor(r);
			Image img = new Bitmap(w, h);
			using (Graphics g = Graphics.FromImage(img))
				g.FillRectangle(new SolidBrush(randomColor), new Rectangle(0, 0, img.Width, img.Height));
			return img;
		}

		public Color GetRandomColor(Random r)
		{
			Thread.Sleep(3);
			return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
		}

		const string letters = "sqwesrty uiopa sdfsghj klszx cvsbsnm abcd efg hig klmnop q rstu vwxyz kojnianw asdqwae d";
		public string GetRandomString(Random r)
		{
			int start = r.Next(letters.Length - 5);
			int length = r.Next(letters.Length - start - 1);
			return letters.Substring(start, length);
		}
	}
}
