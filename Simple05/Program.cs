using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace Simple05
{
    class Program
    {
        static void Main(string[] args)
        {
            test_delMany();
            Console.ReadKey();

        }
        public static void TestInsert() {
            var Content = new Content
            {
                title = "标题",
                content="内容"

            };
            using (var conn = new SqlConnection(@"Data Source=127.0.0.1;User ID=sa;
                Password=123;Initial Catalog=test;Pooling=true;Max Pool Size=100;")) {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, Content);
                Console.WriteLine($"test_insert：插入了{result}条数据！");

            }
        }
        public static void TestInsertMany() {
            List<Content> contents = new List<Content> {
                new Content{
                    title = "批量插入标题1",
                content = "批量插入内容1",
                },
                 new Content{
                    title = "批量插入标题2",
                content = "批量插入内容2",
                }
            };
            using (var conn=new SqlConnection(@"Data Source=127.0.0.1;User ID=sa;
                Password=123;Initial Catalog=test;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");


            }

        }

        public static void test_del()
        {
            var content = new Content
            {
                id = 2
            };
            using (var conn=new SqlConnection(@"Data Source=127.0.0.1;User ID=sa;
                Password=123;Initial Catalog=test;Pooling=true;Max Pool Size=100;"))
            {
                var sql = @"Delete from [Content] where id=@id";
                var result = conn.Execute(sql, content);
                Console.WriteLine($"tesl_del删除了{result}条数据");

            }

        }
        public static void test_delMany() {
            List<Content> contents = new List<Content>
            {
                new Content
                {
                    id=1

                },
                new Content
                {

                    id=3
                }

            };
            using (var conn = new SqlConnection(@"Data Source=127.0.0.1;User ID=sa;
                Password=123;Initial Catalog=test;Pooling=true;Max Pool Size=100;"))
            {
                var sql = @"Delete from [Content] where id=@id";
                var result = conn.Execute(sql, contents);
                Console.WriteLine($"tesl_del删除了{result}条数据");

            }

        }
      
    }
}
