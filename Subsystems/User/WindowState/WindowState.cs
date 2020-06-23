using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Shapes;

namespace DietApplication.User
{
    interface IWindowState
    {
        bool IsTheContainsRadioButtonSelected();
        bool IsDragInProgress();
        Point GetDragStartPoint();
        // Ribbon and QAT
        // Print profile
    }

    class WindowState : IWindowState
    {
        private bool IsTheContainsRadioButtonSelected;
        private bool IsDragInProgress;

        Point IWindowState.GetDragStartPoint()
        {
            throw new NotImplementedException();
        }

        bool IWindowState.IsDragInProgress()
        {
            throw new NotImplementedException();
        }

        bool IWindowState.IsTheContainsRadioButtonSelected()
        {
            throw new NotImplementedException();
        }

        void GetWindowState(Window w)
        {
            //IntPtr windowHandle = new WindowInteropHelper(w).Handle; //Application.Current.MainWindow
            //if (Screen.AllScreens.Length > 1)
            //{
            //    Screen s2 = Screen.AllScreens[1];
            //    Rectangle r2 = s2.WorkingArea;
            //    w.Top = r2.Top;
            //    w.Left = r2.Left;
            //    w.Show();
            //}

            //else
            //{
            //    Screen s1 = Screen.AllScreens[0];
            //    Rectangle r1 = s1.WorkingArea;
            //    w.Top = r1.Top;
            //    w.Left = r1.Left;
            //    w.Show();
            //}
        }
    }
}
