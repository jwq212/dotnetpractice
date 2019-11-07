using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efpractice
{
    internal static class StudentFunction
    {
        /// <summary>
        /// 添加操作
        /// </summary>
        public static void Add()
        {
            //1.实例化实体上下文
            StudentDBEntities2 dbContext = new StudentDBEntities2();

            //2.声明一个T_Student实体
            student1 stu = new student1
            {
                ID = "3",
                Name = "sss",
                Course = "math",
                Score = "100"
                
            };

            //3.告诉上下文对此实体进行添加操作
            dbContext.student1.Add(stu);
            //dbContext.Entry<student1>(stu).State = System.Data.Entity.EntityState.Added;

            //4.告诉上下文把实体的变化保存到数据库
            dbContext.SaveChanges();
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        public static void update()
        {
            //1.实例化实体上下文
            StudentDBEntities2 dbContext = new StudentDBEntities2();

            //dbContext.Database.Connection.ConnectionString = "数据库连接字符串";//运行时修改链接字符串，用于加密重要信息

            //2.声明一个实体
            student1 stu = new student1
            {
                ID = "3",
                Name = "sss",
                Course = "math",
                Score = "100"

            };

            //3.告诉上下文对此实体进行更新操作
            //由于数据库中ID是主键，因此EF可以根据主键ID判断Where判断条件

            dbContext.student1.Attach(stu);//附加到上下文进行跟踪管理
            //dbContext.Entry<student1>(stu).State = System.Data.Entity.EntityState.Detached;//取消上下文对stu实体的跟踪，释放内存

            //dbContext.Entry<student1>(stu).State = System.Data.Entity.EntityState.Modified;//更新整个实体
            dbContext.Entry<student1>(stu).Property<string>(m => m.Score).IsModified = true;//更新实体中的Score字段
                                                                                            //dbContext.Entry<T_Student>(stu).Property("School").IsModified = true;//更新实体中School字段

            //4.告诉上下文保存到数据库中
            dbContext.SaveChanges();

        }
        /// <summary>
        /// 查询操作
        /// </summary>
        public static void select()
        {
            StudentDBEntities2 dbContext = new StudentDBEntities2();

            ////直接使用EF
            //foreach (var stu in dbContext.T_Student.Where(s=>s.ID>1 || s.ID==1))
            //{
            //    Console.WriteLine(stu.ID + " " + stu.Name + " " + stu.Class + " " + stu.College + " " + stu.School);
            //} 
            //使用Linq查询语句
            //Linq表达式的返回值类型是IQueryable<T>
            var query = from s in dbContext.student1
                        where s.Name.Length > 2 || s.ID == "1"
                        select s;
            foreach (var stu in query.ToList())
            {
                Console.WriteLine(stu.ID + " " + stu.Name + " " + stu.Course + " " + stu.Score + " ");
            }

            //IQueryable<student1> temp = from u in dbContext.student1
            //                             where u.Name.Length > 3
            //                             select u;

            //初始化了一下IQueryable接口里面的三个参数
            //1 Linnq表达式转成Expression类型
            //2 给Type ElementType赋值
            //3 给IQueryProvider赋值，EF的provider
            //当用到IQueryable接口的集合的数据的时候，provider解析Expression然后获取相应的数据。进行遍历执行

            //IQueryable<object> parent = temp;

            //Dog aDog = new Dog();
            //Animal aAnimal = aDog;
            //List<Dog> lstDog = new List<Dog>();
            ////List<Animal> lstAnimal = lstDog;
            //List<Animal> lstAnimal2 = lstDog.Select(d => (Animal)d).ToList();
            //IEnumerable<Dog> idog = null;
            //IEnumerable<Animal> ianimal = idog;

            System.Linq.Expressions.Expression<Func<int, bool>> expression = a => a > 0;
        }

    }
}
