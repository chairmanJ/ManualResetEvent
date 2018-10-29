using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ThreadingTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thrd1 = new Thread(new ThreadStart(trmain));
            thrd1.Name = "thread1";//线程命名
            thrd1.Start();
            

            Thread tr = Thread.CurrentThread;
            Console.WriteLine(tr.Name);
            
            for (int x = 0; x < 10; x++）
            {
                Thread.Sleep(900);//每延时900ms输出一次
                Console.WriteLine("Main:"+x);
                if (5 == x) mre.Set();//将事件状态设置为有信号，从而允许一个或多个等待线程继续执行
            }
            while (thrd1.IsAlive)
            {
                Thread.Sleep(1000);//延时一秒输出“等待结束”
                Console.WriteLine("Main:waiting for thread to stop...");
            }

            Console.ReadLine();
        }
        public static ManualResetEvent mre=new ManualResetEvent(false);//通知一个或多个正在等待的线程已发生事件（在某个时间点，新线程暂停并等待从主线程（或其他线程）发来的消息）。
                                                                        //ManualResetEvent建立时是把false作为start的初始状态，这个类用于通知另一个线程，让它等待一个或多个线程。注意，为了通知或监听同一个线程，所有的其他线程都能访问那个类。
        
        public static void trmain()
        {
            Thread tr = Thread.CurrentThread;
            Console.WriteLine(Thread.CurrentThread.Name);//当前线程名称应该为thread1
            Console.WriteLine("thread:waiting for an event");
            mre.WaitOne();//阻止当前线程，直到收到信号
            Console.WriteLine("thread:got an event");
            for (int x=0;x<10;x++)
            {
               
                Thread.Sleep(1000);//。每延时1s输出一次
                Console.WriteLine(x);
            }
        }
    }
}
