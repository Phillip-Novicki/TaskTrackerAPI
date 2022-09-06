namespace MemosBackend
{
    public static class MemosInitializer
    {
        public static void Initialize(MemosContext context)
        {
            context.Database.EnsureCreated();

            if (context.Memos.Any())
                return;

            Memo[] memos = new[]
            {
                new Memo{ Text="memo1", CreatedOn=DateTime.Now.AddDays(0) },
                new Memo{ Text="memo2", CreatedOn=DateTime.Now.AddDays(1) },
                new Memo{ Text="memo3", CreatedOn=DateTime.Now.AddDays(2) },
                new Memo{ Text="memo4", CreatedOn=DateTime.Now.AddDays(3) }
            };

            foreach (var memo in memos)
            {
                context.Memos.Add(memo);
            }

            context.SaveChanges();
        }

    }
}
