namespace WebDemoApi.DataAccessLayer
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using WebDemoApi.DataModel;
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

    public class MyDbInitializer : CreateDatabaseIfNotExists<MySQLDbContext>
    {
        protected override void Seed(MySQLDbContext context)
        {
            context.Word.Add(new JapaneseWord { EntryID = 1, Hiragana = "愛", Kanji = "愛", Romaji = "ai", AdditionalText = string.Empty, MotherTongueTranslation = "love", MotherTongueTranslationLabel = "English" });
            base.Seed(context);
        }
    }
}