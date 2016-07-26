namespace WebDemoApi.DataAccessLayer
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using WebDemoApi.DataModel;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySqlDbContext : DbContext
    {

        public MySqlDbContext() : base("MyDbContextConnectionString")
        {
            Database.SetInitializer<MySqlDbContext>(new MyDbInitializer());

        }
        
        public DbSet<JapaneseWord> Word { get; set; }
     }

    public class MyDbInitializer : DropCreateDatabaseAlways <MySqlDbContext>
    {

        //public MyDbInitializer()
        //{

        //}

        public void InitializeMySqlDatabase(MySqlDbContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
                context.Word.Add(new JapaneseWord { EntryId = 1, Hiragana = "愛", Kanji = "愛", Romaji = "ai", AdditionalText = string.Empty, MotherTongueTranslation = "love", MotherTongueTranslationLabel = "English" });
                context.SaveChanges();
            }
         
        }


        protected override void Seed(MySqlDbContext context)
        {
            context.Word.Add(new JapaneseWord { EntryId = 1, Hiragana = "愛", Kanji = "愛", Romaji = "ai", AdditionalText = string.Empty, MotherTongueTranslation = "love", MotherTongueTranslationLabel = "English" });
            base.Seed(context);
            
        }
    }

    public class MyDbInitializer2 : CreateDatabaseIfNotExists<MySqlDbContext>
    {
        protected override void Seed(MySqlDbContext context)
        {
            context.Word.Add(new JapaneseWord { EntryId = 1, Hiragana = "愛", Kanji = "愛", Romaji = "ai", AdditionalText = string.Empty, MotherTongueTranslation = "love", MotherTongueTranslationLabel = "English" });
            base.Seed(context);
            
        }
    }

    public class MyDbInitializer3 : DropCreateDatabaseIfModelChanges<MySqlDbContext>
    {
        protected override void Seed(MySqlDbContext context)
        {
            context.Word.Add(new JapaneseWord { EntryId = 1, Hiragana = "愛", Kanji = "愛", Romaji = "ai", AdditionalText = string.Empty, MotherTongueTranslation = "love", MotherTongueTranslationLabel = "English" });
            base.Seed(context);
            
        }
    }
}