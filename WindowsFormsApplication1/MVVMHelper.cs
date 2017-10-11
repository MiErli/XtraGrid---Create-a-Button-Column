using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApplication1
{
    public class MVVMHelper
    {
        public static void AssignDataSourceToGrid(GridControl grid, object dataSource)
        {
            grid.DataSource = dataSource;
            CreateButtonColumn(grid);
        }

        static void CreateButtonColumn(GridControl grid)
        {
            GridView view = grid.MainView as GridView;
            GridColumn colButton = view.Columns.AddVisible("colButton");
            colButton.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            colButton.ColumnEdit = CreateEdit(grid);
        }

        static RepositoryItemButtonEdit CreateEdit(GridControl grid)
        {
            RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit{
                            TextEditStyle = TextEditStyles.HideTextEditor,};

            edit.Buttons.Clear();
            var x = new EditorButton(ButtonPredefines.Glyph, "Button-1", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, GetButtonImage());
            x.Click += X_Click;


            var button2 = new EditorButton(ButtonPredefines.Glyph, "Button-2", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, GetButtonImage2());
            button2.Click += Button2_Click;


            edit.Buttons.AddRange(new EditorButton[] { x,button2 });
            grid.RepositoryItems.Add(edit);
            return edit;
        }

        private static void Button2_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("hallo vom BUTTON-2.", "Button-2-Click");
        }

        private static void X_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("hallo welt.", "Button-1-Click");
        }

        static Image GetButtonImage()
        {
            int w = 16;
            int h = 16;
            Brush b = Brushes.Orange;
            Image img = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillEllipse(b, new Rectangle(0, 0, w - 1, h - 1));
            }
            return img;
        }
        static Image GetButtonImage2()
        {
            int w = 16;
            int h = 16;
            Brush b = Brushes.LawnGreen;
            Image img = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillEllipse(b, new Rectangle(0, 0, w - 1, h - 1));
            }
            return img;
        }

    }
}
