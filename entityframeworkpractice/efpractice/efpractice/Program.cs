//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace efpractice
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
            
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace efpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentFunction.select();
            //创建数据库访问网关
            using (StudentDBEntities2 schoolEntities = new StudentDBEntities2())
            {
                //查询到老师对应的班级的外键，注意是使用的linq to ef ,它是生成的命令树，然后是生成的sql

                var cls = (from c in schoolEntities.student1
                           where c.ID == "1"
                           select c);
                //创建teacher一个实体
                student1 st = new student1();
                st.ID = "3";
                st.Name = "JWQ2";
                st.Course = "Chnise";
                st.Score = "100";

                
                //将创建的实体，放入网关的数据实体的集合
                schoolEntities.student1.Add(st);
                //写回数据库
                schoolEntities.SaveChanges();
            }
            Console.WriteLine("OK");
        }
    }
}
