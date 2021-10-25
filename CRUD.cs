using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Lesson25._3
{
    internal class CRUD
    {
        public static async Task<User> Insert(User user)
        {
            using (var db = new AlifAcademyContext())
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
            return user;
        }
        public static async Task<User> Get(string name)
        {
            using (var db = new AlifAcademyContext())
            {
                return await db.Users.FirstOrDefaultAsync(x => x.Name == name);
            }
        }
        public static async Task Update(User user)
        {
            using (var db = new AlifAcademyContext())
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
            }
        }
        public static async Task Delete(User user)
        {
            using (var db = new AlifAcademyContext())
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
