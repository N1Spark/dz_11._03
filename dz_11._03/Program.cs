using StockProductLibrary;
using StockProductLibraryContext;
using System.ComponentModel;
using System.Diagnostics;

namespace dz_11._03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //addElements();
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Отображение всей информации о товаре");
            Console.WriteLine("2. Отображение всех типов товаров");
            Console.WriteLine("3. Отображение всех поставщиков");
            Console.WriteLine("4. Показать товар с максимальным количеством");
            Console.WriteLine("5. Показать товар с минимальным количеством");
            Console.WriteLine("6. Показать товар с минимальной себестоимостью");
            Console.WriteLine("7. Показать товар с максимальной себестоимостью");
            Console.WriteLine("8. Показать товары, заданной категории");
            Console.WriteLine("9. Показать товары, заданного поставщика");
            Console.WriteLine("10. Показать самый старый товар на складе");
            Console.WriteLine("11. Показать среднее количество товаров по каждому типу товара");
            Console.WriteLine("12. Вставка новых товаров");
            Console.WriteLine("13. Вставка новых поставщиков");
            Console.WriteLine("14. Обновление информации о существующих товарах");
            Console.WriteLine("15. Обновление информации о существующих поставщиках");
            Console.WriteLine("16. Удаление товаров");
            Console.WriteLine("17. Удаление поставщиков");
            Console.WriteLine("18. Показать информацию о поставщике с наибольшим количеством товаров на складе");
            Console.WriteLine("19. Показать информацию о поставщике с наименьшим количеством товаров на складе");
            Console.WriteLine("20. Показать информацию о типе товаров с наибольшим количеством товаров на складе");
            Console.WriteLine("21. Показать информацию о типе товаров с наименьшим количеством товаров на складе\n");
            int temp = Convert.ToInt32(Console.ReadLine()!);
            switch (temp)
            {
                case 1:
                    ShowAll();
                    break;
                case 2:
                    ShowAllType();
                    break;
                case 3:
                    ShowAllProvider();
                    break;
                case 4:
                    ShowMaxCount();
                    break;
                case 5:
                    ShowMinCount();
                    break;
                case 6:
                    ShowMinPrice();
                    break;
                case 7:
                    ShowMaxPrice();
                    break;
                case 8:
                    ShowProductByCategory();
                    break;
                case 9:
                    ShowProductByProvider();
                    break;
                case 10:
                    ShowElderProduct();
                    break;
                case 11:
                    ShowAvgEachType();
                    break;
                case 12:
                    AddNewProduct();
                    break;
                case 13:
                    AddNewProvider();
                    break;
                case 14:
                    UpdateProductInfo();
                    break;
                case 15:
                    UpdateProviderInfo();
                    break;
                case 16:
                    DeleteProduct();
                    break;
                case 17:
                    DeleteProvider();
                    break;
                case 18:
                    ShowProviderMaxCountProducts();
                    break;
                case 19:
                    ShowProviderMinCountProducts();
                    break;
                case 20:
                    ShowTypeMaxCountProducts();
                    break;
                case 21:
                    ShowTypeMinCountProducts();
                    break;
            }
        }
        static void ShowAll()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var query = (from pr in db.Products
                             select pr).ToList();
                foreach (var item in query)
                {
                    Console.WriteLine("Product: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Price: " + item.Price + "$");
                    Console.WriteLine("Count: " + item.Count);
                    Console.WriteLine("Date: " + item.Date);
                    Console.WriteLine("Provider: " + item.Provider?.Name);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowAllType()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var types = db.Products.Select(p => p.Type).Distinct().ToList();
                foreach (var type in types)
                    Console.WriteLine(type);
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowAllProvider()
        {
            Console.Clear();
            using (var db = new StockProductContext())
                foreach (var item in db.Providers)
                    Console.WriteLine(item.Name);
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowMaxCount()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var item = db.Products.OrderByDescending(p => p.Count).FirstOrDefault();
                if (item != null)
                {
                    Console.WriteLine("Product: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Price: " + item.Price + "$");
                    Console.WriteLine("Count: " + item.Count);
                    Console.WriteLine("Date: " + item.Date);
                    Console.WriteLine("Provider: " + item.Provider?.Name);
                }
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowMinCount()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var item = db.Products.OrderBy(p => p.Count).FirstOrDefault();
                if (item != null)
                {
                    Console.WriteLine("Product: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Price: " + item.Price + "$");
                    Console.WriteLine("Count: " + item.Count);
                    Console.WriteLine("Date: " + item.Date);
                    Console.WriteLine("Provider: " + item.Provider?.Name);
                }
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowMinPrice()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var item = db.Products.OrderBy(p => p.Price).FirstOrDefault();
                if (item != null)
                {
                    Console.WriteLine("Product: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Price: " + item.Price + "$");
                    Console.WriteLine("Count: " + item.Count);
                    Console.WriteLine("Date: " + item.Date);
                    Console.WriteLine("Provider: " + item.Provider?.Name);
                }
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowMaxPrice()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var item = db.Products.OrderByDescending(p => p.Price).FirstOrDefault();
                if (item != null)
                {
                    Console.WriteLine("Product: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Price: " + item.Price + "$");
                    Console.WriteLine("Count: " + item.Count);
                    Console.WriteLine("Date: " + item.Date);
                    Console.WriteLine("Provider: " + item.Provider?.Name);
                }
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowProductByCategory()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                Console.WriteLine("Все категории:");
                var types = db.Products.Select(p => p.Type).Distinct().ToList();
                foreach (var type in types)
                    Console.WriteLine(type);
                Console.Write("\nВведите постащика: ");
                string search = Console.ReadLine()!;
                var items = db.Products.Where(p => p.Type == search);
                if (items != null)
                {
                    Console.WriteLine();
                    foreach (var item in items)
                    {
                        Console.WriteLine("Product: " + item.Name);
                        Console.WriteLine("Type: " + item.Type);
                        Console.WriteLine("Price: " + item.Price + "$");
                        Console.WriteLine("Count: " + item.Count);
                        Console.WriteLine("Date: " + item.Date);
                        Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("Такой категории нет");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowProductByProvider()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                Console.WriteLine("Все поставщики:");
                foreach (var item in db.Providers)
                    Console.WriteLine(item.Name);
                Console.Write("\nВведите постащика: ");
                string search = Console.ReadLine()!;
                var items = db.Products.Where(p => p.Provider.Name == search);
                if (items != null)
                {
                    Console.WriteLine();
                    foreach (var item in items)
                    {
                        Console.WriteLine("Product: " + item.Name);
                        Console.WriteLine("Type: " + item.Type);
                        Console.WriteLine("Price: " + item.Price + "$");
                        Console.WriteLine("Count: " + item.Count);
                        Console.WriteLine("Date: " + item.Date);
                        Console.WriteLine("Provider: " + item.Provider?.Name);
                        Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("Такого поставщика нет");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowElderProduct()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var item = db.Products.OrderBy(p => p.Date).FirstOrDefault();
                if (item != null)
                {
                    Console.WriteLine("Product: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Price: " + item.Price + "$");
                    Console.WriteLine("Count: " + item.Count);
                    Console.WriteLine("Date: " + item.Date);
                    Console.WriteLine("Provider: " + item.Provider?.Name);
                }
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowAvgEachType()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var averageCountsByType = db.Products
                .GroupBy(p => p.Type)
                .Select(g => new
                {
                    Type = g.Key,
                    AverageCount = g.Average(p => p.Count)
                })
                .ToList();

                Console.WriteLine("Среднее количество товаров по каждому типу товара:");
                foreach (var item in averageCountsByType)
                    Console.WriteLine($"Тип: {item.Type}, Среднее количество: {item.AverageCount}");
                Console.WriteLine();
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void AddNewProduct()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                Console.WriteLine("Название продукта: ");
                string p_name = Console.ReadLine()!;
                Console.WriteLine("Тип: ");
                string p_type = Console.ReadLine()!;
                Console.WriteLine("Выберите постващика: ");
                Provider p_provider = null!;

                foreach (var item in db.Providers)
                    Console.WriteLine(item.Name);
                Console.WriteLine();
                string temp = Console.ReadLine()!;
                foreach (var item in db.Providers)
                    if (item.Name == temp)
                        p_provider = item;
                Console.WriteLine("Количество: ");
                int p_count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Цена: ");
                int p_price = Convert.ToInt32(Console.ReadLine());
                var product = new Product
                {
                    Name = p_name,
                    Type = p_type,
                    Provider = p_provider!,
                    Count = p_count,
                    Price = p_price,
                    Date = DateTime.Now
                };
                db.Products.Add(product);
                db.SaveChanges();
                Console.WriteLine("Продукт добавлен");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void AddNewProvider()
        {
            Console.Clear();
            Console.WriteLine("Введите название поставщика");
            string provider_name = Console.ReadLine()!;
            if (provider_name != null)
            {
                using (var db = new StockProductContext())
                {
                    var provider = new Provider { Name = provider_name };
                    db.Providers.Add(provider);
                    db.SaveChanges();
                    Console.WriteLine("Провайдер добавлен");
                }
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void UpdateProductInfo()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var query = (from pr in db.Products
                             select pr).ToList();
                foreach (var item in query)
                {
                    Console.WriteLine("ID: " + item.Id);
                    Console.WriteLine("Product: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Price: " + item.Price + "$");
                    Console.WriteLine("Count: " + item.Count);
                    Console.WriteLine("Date: " + item.Date);
                    Console.WriteLine("Provider: " + item.Provider?.Name);
                    Console.WriteLine();
                }

                Console.WriteLine("Введите ID товара для обновления: ");
                int p_id = Convert.ToInt32(Console.ReadLine());
                var productToUpdate = db.Products.FirstOrDefault(p => p.Id == p_id);

                if (productToUpdate != null)
                {
                    Console.WriteLine("Название продукта: ");
                    productToUpdate.Name = Console.ReadLine()!;
                    Console.WriteLine("Тип: ");
                    productToUpdate.Type = Console.ReadLine()!;
                    Console.WriteLine("\nВыберите постващика: ");

                    foreach (var item in db.Providers)
                        Console.WriteLine(item.Name);
                    Console.WriteLine();
                    string temp = Console.ReadLine()!;
                    foreach (var item in db.Providers)
                        if (item.Name == temp)
                            productToUpdate.Provider = item;

                    Console.WriteLine("Количество: ");
                    productToUpdate.Count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Цена: ");
                    productToUpdate.Price = Convert.ToInt32(Console.ReadLine());
                    productToUpdate.Date = DateTime.Now;

                    db.SaveChanges();
                }
                else
                    Console.WriteLine("Продукт не был найден");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void UpdateProviderInfo()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                foreach (var item in db.Providers)
                    Console.WriteLine("ID: " + item.Id + "\tName: " + item.Name);
                Console.WriteLine();
                Console.WriteLine("Введите ID поставщика для обновления: ");
                int p_id = Convert.ToInt32(Console.ReadLine());
                var providerToUpdate = db.Providers.FirstOrDefault(p => p.Id == p_id);
                if (providerToUpdate != null)
                {
                    Console.WriteLine("Название поставщика: ");
                    providerToUpdate.Name = Console.ReadLine()!;
                    db.SaveChanges();
                }
                else
                    Console.WriteLine("Поставщик не был найден");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void DeleteProduct()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var query = (from pr in db.Products
                             select pr).ToList();
                foreach (var item in query)
                {
                    Console.WriteLine("ID: " + item.Id);
                    Console.WriteLine("Product: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Price: " + item.Price + "$");
                    Console.WriteLine("Count: " + item.Count);
                    Console.WriteLine("Date: " + item.Date);
                    Console.WriteLine("Provider: " + item.Provider?.Name);
                    Console.WriteLine();
                }

                Console.WriteLine("Введите ID товара для удаления: ");
                int p_id = Convert.ToInt32(Console.ReadLine());
                var productToDelete = db.Products.FirstOrDefault(p => p.Id == p_id);
                if (productToDelete != null)
                {
                    db.Products.Remove(productToDelete);
                    db.SaveChanges();
                    Console.WriteLine("\nПродукт был удален\n");
                }
                else
                    Console.WriteLine("Продукт не был найден");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void DeleteProvider()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                foreach (var item in db.Providers)
                    Console.WriteLine("ID: " + item.Id + "\tName: " + item.Name);
                Console.WriteLine();
                Console.WriteLine("Введите ID поставщика для обновления: ");
                int p_id = Convert.ToInt32(Console.ReadLine());
                var providerToDelete = db.Providers.FirstOrDefault(p => p.Id == p_id);
                if (providerToDelete != null)
                {
                    db.Providers.Remove(providerToDelete);
                    db.SaveChanges();
                    Console.WriteLine("\nПоставщик был удален\n");
                }
                else
                    Console.WriteLine("Поставщик не был найден");
            }
            Console.WriteLine("\nНажмите на любую кнопку для вызова меню");
            Console.ReadKey();
            Menu();
        }
        static void ShowProviderMaxCountProducts()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var providerWithMaxProducts = db.Products
                .GroupBy(p => p.Provider)
                .Select(g => new
                {
                    Provider = g.Key,
                    TotalCount = g.Sum(p => p.Count)
                })
                .OrderByDescending(x => x.TotalCount)
                .FirstOrDefault();

                if (providerWithMaxProducts != null)
                {
                    Console.WriteLine("Поставщик с наибольшим количеством товаров:");
                    Console.WriteLine($"Поставщик: {providerWithMaxProducts.Provider?.Name}");
                    Console.WriteLine($"Кол-во: {providerWithMaxProducts.TotalCount}");
                }
                else
                    Console.WriteLine("Продуктов не было найдено");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowProviderMinCountProducts()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var providerWithMinProducts = db.Products
                .GroupBy(p => p.Provider)
                .Select(g => new
                {
                    Provider = g.Key,
                    TotalCount = g.Sum(p => p.Count)
                })
                .OrderBy(x => x.TotalCount)
                .FirstOrDefault();

                if (providerWithMinProducts != null)
                {
                    Console.WriteLine("Поставщик с наименьшим количеством товаров:");
                    Console.WriteLine($"Поставщик: {providerWithMinProducts.Provider?.Name}");
                    Console.WriteLine($"Кол-во: {providerWithMinProducts.TotalCount}");
                }
                else
                    Console.WriteLine("Продуктов не было найдено");
            }
            Console.WriteLine("\nНажмите на любую кнопку для вызова меню");
            Console.ReadKey();
            Menu();
        }
        static void ShowTypeMaxCountProducts()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var typeWithMaxProducts = db.Products
                .GroupBy(p => p.Type)
                .Select(g => new
                {
                    Type = g.Key,
                    TotalCount = g.Sum(p => p.Count)
                })
                .OrderByDescending(x => x.TotalCount)
                .FirstOrDefault();

                if (typeWithMaxProducts != null)
                {
                    Console.WriteLine("Типы товаров с наибольшим количеством товаров:");
                    Console.WriteLine($"Тип: {typeWithMaxProducts.Type}");
                    Console.WriteLine($"Кол-во: {typeWithMaxProducts.TotalCount}");
                }
                else
                    Console.WriteLine("Продуктов не было найдено");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void ShowTypeMinCountProducts()
        {
            Console.Clear();
            using (var db = new StockProductContext())
            {
                var typeWithMinProducts = db.Products
                .GroupBy(p => p.Type)
                .Select(g => new
                {
                    Type = g.Key,
                    TotalCount = g.Sum(p => p.Count)
                })
                .OrderBy(x => x.TotalCount)
                .FirstOrDefault();

                if (typeWithMinProducts != null)
                {
                    Console.WriteLine("Типы товаров с наименьшим количеством товаров:");
                    Console.WriteLine($"Тип: {typeWithMinProducts.Type}");
                    Console.WriteLine($"Кол-во: {typeWithMinProducts.TotalCount}");
                }
                else
                    Console.WriteLine("Продуктов не было найдено");
            }
            Console.WriteLine("\nЧтобы продолжить нажмите любую кнопку");
            Console.ReadKey();
            Menu();
        }
        static void addElements()
        {
            using (var db = new StockProductContext())
            {
                var provider1 = new Provider { Name = "Rozetka" };
                var provider2 = new Provider { Name = "Comfy" };
                var provider3 = new Provider { Name = "Allo" };
                db.Providers.AddRange(provider1, provider2, provider3);
                db.SaveChanges();
                var product1 = new Product
                {
                    Name = "Laptop",
                    Type = "Electronics",
                    Provider = provider3,
                    Count = 50,
                    Price = 1999,
                    Date = DateTime.Now
                };
                var product2 = new Product
                {
                    Name = "Phone",
                    Type = "Electronics",
                    Provider = provider1,
                    Count = 100,
                    Price = 499,
                    Date = DateTime.Now
                };
                var product3 = new Product
                {
                    Name = "Potatoes",
                    Type = "Grocery",
                    Provider = provider1,
                    Count = 200,
                    Price = 1,
                    Date = DateTime.Now
                };
                var product4 = new Product
                {
                    Name = "Pens",
                    Type = "Stationery",
                    Provider = provider3,
                    Count = 300,
                    Price = 2,
                    Date = DateTime.Now
                };

                var product5 = new Product
                {
                    Name = "Tomatoes",
                    Type = "Grocery",
                    Provider = provider2,
                    Count = 80,
                    Price = 1,
                    Date = DateTime.Now
                };
                var product6 = new Product
                {
                    Name = "Shoes",
                    Type = "Footwear",
                    Provider = provider2,
                    Count = 50,
                    Price = 99,
                    Date = DateTime.Now
                };
                db.Products.AddRange(product1, product2, product3, product4, product5, product6);
                db.SaveChanges();
                Console.WriteLine("Done");
            }
        }
    }
}