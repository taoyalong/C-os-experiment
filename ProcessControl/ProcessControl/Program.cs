using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProcessContor
{
    public struct jincheng_type
    {
        public int pid;//进程编号
        public int youxian;//进程优先级
        public int zhuangtai;//进程状态
        public int daxiao;//进程大小
        //进程内容
        public  Char info;
    }
    public class process1
    {

        jincheng_type[] jincheng = new jincheng_type[20];
        public int shumu = 0, guaqi = 0, pid;
        public int flag = 0;
        public void create()
        {
            if (shumu >=20) Console.Write("\n 内存已满，请先换出或杀死进程\n");
            else
            {
               
                    
                    Console.Write("\n 请输入新进程 pid\n");
                    jincheng[shumu].pid = Convert.ToInt32(Console.ReadLine());
                    for (int j = 0; j < shumu; j++)
                        if (jincheng[shumu].pid == jincheng[j].pid)
                        {// 判断进程是否存在
                            Console.Write("\n 该进程已存在\n");
                            return;
                        }
                    Console.Write("\n 请输入新进程优先级\n"); //进程优先级设置
                    jincheng[shumu].youxian = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n 请输入新进程大小\n"); //输入进程大小
                    jincheng[shumu].daxiao = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n 请输入新进程内容\n"); //进程内容
                    jincheng[shumu].info = Convert.ToChar(Console.ReadLine());
                    //创建进程，使标记位为 1 
                    jincheng[shumu].zhuangtai = 1; //修改进程状态
                    shumu++; //进程数目加1
                
            }
        }

        public void run()
        {
            for (int i = 0; i < 20; i++)
            {
                if (jincheng[i].zhuangtai == 1)
                {
                    Console.Write("进程id:{0}\n", jincheng[i].pid );
                    Console.Write("优先级:{0}\n", jincheng[i].youxian);
                    Console.Write("进程状态:{0}\n", jincheng[i].zhuangtai);
                    Console.Write("进程内容:{0}\n", jincheng[i].info);
                    flag = flag++;
                }
            }
            if(flag<=0)Console.WriteLine("当前没有可运行进程");
        }

        public void outer()
        {
        if(shumu==0)
           {
               Console.WriteLine("当前没有进程运行");
               return;
            }
        Console.WriteLine("输入换入进程的ID值");
        pid=Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < 20; i++)
        {
#region      
            if (pid == jincheng[i].pid)
            {
                jincheng[i].zhuangtai = 2;
                guaqi++;
                Console.WriteLine("成功换出");
            }
            else if (jincheng[i].zhuangtai == 0)
            {
                Console.WriteLine("要换出的进程不存在");
            }
            else Console.WriteLine("要换出的进程已挂起");
            flag = flag--;
            break;
#endregion           
        }
        }

        public void kill()
        {
            #region
            if (shumu == 0)
            {
                Console.WriteLine("当前没有进程");
                return;
            }
           #endregion
           #region
            Console.WriteLine("输入杀死进程的ID值");
             pid = Convert.ToInt32(Console.ReadLine());
             for (int i = 0; i < 20; i++)
             {
                 if (pid == jincheng[i].pid) 
                 {
                     if (jincheng[i].zhuangtai == 1)
                     {
                         jincheng[i].zhuangtai = 0;
                         shumu--;
                         Console.WriteLine("已经杀死进程");
                         return;
                     }
                     else Console.WriteLine("要换出的进程已挂起");

                 }
                 else if (jincheng[i].zhuangtai == 0) Console.WriteLine("要杀死的进程不存在");
                 flag = flag--;
                 break;
             }

             #endregion
            if(flag<=0)
            {
              Console.WriteLine("要杀死的进程不存在");  
            }
        }
        
        public void huanxing()
        {
            if(shumu==0)
            {
                Console.WriteLine("当前没有运行的进程");
                return;
            }
            if(guaqi==0)
            {
                Console.WriteLine("当前没有挂起的进程");
                return;
            }
                Console.WriteLine("请输入要唤醒的进程");
                pid=Convert.ToInt32(Console.ReadLine());
                for(int i=0;i<20;i++)
                {
                    if(pid==jincheng[i].pid)
                    {
                        flag = flag++;
                        if (jincheng[i].zhuangtai == 2)
                     {
                         jincheng[i].zhuangtai = 1;
                         guaqi--;
                         Console.WriteLine("已经唤醒进程");
                         return;
                     } else if (jincheng[i].zhuangtai == 1) Console.WriteLine("要唤醒的进程已经处于运行态");
                    }
                }
        }    
    }













        class Program
        {
            static void Main(string[] args)
            {
                jincheng_type[] jincheng = new jincheng_type[20];
                process1 process1 = new process1();
                
                int n = 1;
                int num;
                for (int i = 0; i < 20; i++)
                    jincheng[i].zhuangtai = 0;
                while (n==1)
                {
                    Console.WriteLine("**************************************");
                    Console.WriteLine("进入演示系统");
                    Console.WriteLine("**************************************");
                    Console.WriteLine("*1.创建新进程   2.查看运行进程");
                    Console.WriteLine("*3.换出某个进程 4.杀死运行进程");
                    Console.WriteLine("*5.唤醒某个进程 6.退出系统");
                    Console.WriteLine("**************************************");
                    Console.WriteLine("请输入（1-6）");
                    num=Convert.ToInt32(Console.ReadLine());
                    switch (num)
                    {
                        case 1: process1.create();break;
                        case 2: process1.run();break;
                        case 3: process1.outer(); break;
                        case 4: process1.kill(); break;
                        case 5: process1.huanxing(); break;
                        case 6: Environment.Exit(0); break;
                        default: n = 0; break;
                    }
                    process1.flag = 0;
                }
                
            }
        }
    
}
