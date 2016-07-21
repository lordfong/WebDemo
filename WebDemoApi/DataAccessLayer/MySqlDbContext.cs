﻿namespace WebDemoApi.DataAccessLayer
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using WebDemoApi.DataModel;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLDbContext : DbContext
    {

        public MySQLDbContext() : base("MyDbContextConnectionString")
        {
            Database.SetInitializer<MySQLDbContext>(new MyDbInitializer());

        }

        public DbSet<JapaneseWord> Word { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class MyDbInitializer : DropCreateDatabaseIfModelChanges <MySQLDbContext>
    {
        protected override void Seed(MySQLDbContext context)
        {
            base.Seed(context);
            context.Word.Add(new JapaneseWord { EntryId = 1, Hiragana = "愛", Kanji = "愛", Romaji = "ai", AdditionalText = string.Empty, MotherTongueTranslation = "love", MotherTongueTranslationLabel = "English" });
            context.SaveChanges();
        }
    }
}