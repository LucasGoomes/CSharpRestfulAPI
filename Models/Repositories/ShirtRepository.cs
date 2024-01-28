namespace CSharpRestfulAPI.Models.Repositories
{
    public static class ShirtRepository
    {

        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand = "My brand", Color = "Blue", Gender = "Men", Price = 9.99, Size = 10 },
            new Shirt {ShirtId = 2, Brand = "My brand", Color = "Red", Gender = "Woman", Price = 9.99, Size = 10 },

        };

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&

            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&

            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&

            size.HasValue && x.Size.HasValue && x.Size.Value == size.Value
            );
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Gender = shirt.Gender;
        }

        public static void DeleteShirt(int id)
        {
            var shirtToDelete = GetShirtById(id);
            if (shirtToDelete != null)
            {
                shirts.Remove(shirtToDelete);
            }

        }
    }
}
