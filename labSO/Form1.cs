using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static labSO.WinApiClass;

namespace labSO
{


    public partial class Form1 : Form
    {
        uint threadID1;
        uint threadID2;
        uint threadID3;
        UInt32 stackSize = 1024;
       public WinApiClass.ThreadState flags = new WinApiClass.ThreadState();
      
       


        public Form1()
        {
            InitializeComponent();
            uint threadID1;
            uint threadID2;
            uint threadID3;
            UInt32 stackSize = 1024;
            var flags=new WinApiClass.ThreadState();
            var startAdress1 = new WinApiClass.LPTHREAD_START_ROUTINE(thread1);
            var startAdress2 = new WinApiClass.LPTHREAD_START_ROUTINE(thread2);
            var startAdress3 = new WinApiClass.LPTHREAD_START_ROUTINE(thread3);
           
            
            

             threadID1=WinApiClass.CreateThread(IntPtr.Zero,
                                     stackSize,
                                     startAdress1,
                                     IntPtr.Zero,
                                     flags,
                                     out threadID1);

             threadID2=WinApiClass.CreateThread(IntPtr.Zero,
                                    stackSize,
                                    startAdress2,
                                    IntPtr.Zero,
                                    flags,
                                    out threadID2);

             threadID3=WinApiClass.CreateThread(IntPtr.Zero,
                                    stackSize,
                                    startAdress3,
                                    IntPtr.Zero,
                                    flags,
                                    out threadID3);


        }
        
         uint thread1(IntPtr param1) {
            while (  progressBar1.Value != progressBar1.Maximum)
            {
                progressBar1.Increment(1);
                
            }
            return 0;    }
        uint thread2(IntPtr param2) {
            while (progressBar2.Value != progressBar2.Maximum)
            {
                progressBar2.Increment(5);
                
            }
            return 0;
        }
        uint thread3(IntPtr param3) {
            while (progressBar3.Value != progressBar3.Maximum)
            {
                progressBar3.Increment(7);
               
            }
            return 0;    }

        private void button1_Click(object sender, EventArgs e)
        {
            var threadPtr1 = new IntPtr(threadID1);
            WinApiClass.ResumeThread(threadPtr1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var threadPtr1 = new IntPtr(threadID1);
            WinApiClass.SuspendThread(threadPtr1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var threadPtr2 = new IntPtr(threadID2);
            WinApiClass.ResumeThread(threadPtr2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var threadPtr2 = new IntPtr(threadID2);
            WinApiClass.SuspendThread(threadPtr2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var threadPtr3 = new IntPtr(threadID3);
            WinApiClass.ResumeThread(threadPtr3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var threadPtr3 = new IntPtr(threadID3);
            WinApiClass.SuspendThread(threadPtr3);
        }
    }
}
