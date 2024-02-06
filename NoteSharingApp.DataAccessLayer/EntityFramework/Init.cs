using NoteSharingApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NoteSharingApp.DataAccessLayer.EntityFramework
{
    internal class Init : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //admin
            EvernoteUser admin = new EvernoteUser()
            {
                Name = "ad",
                Surname = "min",
                Email = "ad@min.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "admin",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "admin",

            };
            //standart user
            EvernoteUser standartuser = new EvernoteUser()
            {
                Name = "standart",
                Surname = "user",
                Email = "standart@user.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "standartuser",
                Password = "123456",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "admin",

            };

            context.EvernoteUsers.Add(admin);
            context.EvernoteUsers.Add(standartuser);
            // fake users
            for (int i = 0; i < 8; i++)
            {
                EvernoteUser user = new EvernoteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    Username = "",
                    Password = "123",
                    CreatedOn = DateTime.Now.AddHours(1),
                    ModifiedOn = DateTime.Now.AddMinutes(65),
                    ModifiedUsername = $"User{i}",
                };
                user.Username = $"{user.Name}{user.Surname}";
                context.EvernoteUsers.Add(user);
            }
            context.SaveChanges();

            List<string> FakeCategories = new List<string> { "Sports", "Broadcast", "Music", "Software", "Math", "News", "Travel", "People", "Books", "Movies" };
            //fake categories
            for (int i = 0; i < 10; i++)
            {
                List<EvernoteUser> userlist = context.EvernoteUsers.ToList();

                Category cat = new Category()
                {
                    Title = FakeCategories[i],
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "admin",

                };
                context.Categories.Add(cat);
                // notes for categories
                for (int j = 0; j < FakeData.NumberData.GetNumber(5, 9); j++)
                {
                    EvernoteUser note_owner = userlist[FakeData.NumberData.GetNumber(1, 10)];
                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        Category = cat,
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = note_owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = note_owner.Username
                    };

                    cat.Notes.Add(note);

                    //comments for notes
                    for (int k = 0; k < FakeData.NumberData.GetNumber(3, 5); k++)
                    {
                        EvernoteUser Comment_Owner = userlist[FakeData.NumberData.GetNumber(1, 10)];
                        Comment comment = new Comment()
                        {
                            text = FakeData.TextData.GetSentences(1),
                            Note = note,
                            Owner = Comment_Owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = Comment_Owner.Username
                        };

                        note.Comments.Add(comment);

                        //adding fake likes..

                    }

                    for (int m = 0; m < note.LikeCount; m++)
                    {
                        Liked liked = new Liked()
                        {
                            LikedUser = userlist[m]
                        };
                        note.Likes.Add(liked);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
