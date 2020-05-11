﻿using AtuApi.Interfaces;
using AtuApi.Models;
using DataContextHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }

        private DataContext UserContext => Context as DataContext;

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = GetByUserName(username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            //if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //    return null;

            // authentication successful
            return user;
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (GetByUserName(user.UserName) != null)
                throw new Exception("Username \"" + user.UserName + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

       
            UserContext.Users.Add(user);
            UserContext.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            var user = UserContext.Users.Find(id);
            if (user != null)
            {
                UserContext.Users.Remove(user);
                UserContext.SaveChanges();
            }
        }

        public User GetById(int id)
        {
          //  var user = UserContext.Users.Include(x => x.Roles).ThenInclude(p => p.PermissionRoles).Include(b => b.Branches).FirstOrDefault(u => u.Id == id.ToString());
            return null;
        }

        public User GetByUserName(string username)
        {
           return UserContext.Users.FirstOrDefault(u=>u.UserName == username);
        }

        public void Update(User userParam, string password = null)
        {
            
                User user = UserContext.Users.Find(userParam.Id);
                if (user == null)
                    throw new Exception("User not found");

                if (userParam.UserName != user.UserName)
                {
                    // username has changed so check if the new username is already taken
                    if (UserContext.Users.Any(x => x.UserName == userParam.UserName))
                        throw new Exception("Username " + userParam.UserName + " is already taken");
                }

                // update user properties
                user.FirstName = userParam.FirstName;
                user.LastName = userParam.LastName;
                user.UserName = userParam.UserName;
                user.Email = userParam.Email;
                user.Position = userParam.Position;
               
                user.Branches = userParam.Branches;


                // update password if it was entered
                if (!string.IsNullOrWhiteSpace(password))
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(password, out passwordHash, out passwordSalt);

                    //user.PasswordHash = passwordHash;
                  
                }

            UserContext.Users.Update(user);
            UserContext.SaveChanges();
            
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}