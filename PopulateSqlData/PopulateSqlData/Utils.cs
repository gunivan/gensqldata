using HaVaControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData
{
    public class Utils
    {
        #region Loading icon
        public static void VisibleLoading(LoadingCircle loading, Boolean visibled = true)
        {
            loading.ExeInvoke(() =>
            {
                if (visibled)
                {
                    loading.SuspendLayout();

                    var parent = loading.ParentAnchor;
                    if (null != parent)
                    {
                        parent.ExeInvoke(() =>
                        {
                            var x = parent.Location.X + parent.Width / 2 - loading.Width / 2;
                            var y = parent.Location.Y + parent.Height / 2 - loading.Height / 2;
                            loading.Location = new Point(x, y);
                        });
                    }
                }

                loading.Visible = visibled;
                loading.Active = visibled;

                if (visibled)
                {
                    loading.ResumeLayout();
                    loading.Refresh();
                }
            });
        }
        #endregion
    }
}
