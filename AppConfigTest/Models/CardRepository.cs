using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Models
{
    public interface ICardRepository
    {
        IEnumerable<Card> Cards { get; }
        void AddCard(Card card);
    }
    public class CardRepository : ICardRepository
    {
        private List<Card> cards = new List<Card>
        {
            new Card {  Header = "Lily",
                        ImageSrc = "https://bipbap.ru/wp-content/uploads/2017/04/107.jpeg",
                        Price = 13.45m,
                        Description = $"Lily is a beautifull flower that you can buy right now"
            },
            new Card {  Header = "Unknown",
                        ImageSrc = "https://bipbap.ru/wp-content/uploads/2017/04/normal_Fioletovyy_cvetok_makro.jpg",
                        Price = 9.45m,
                        Description = $"This is unknown flower, but you can buy it in our shop"
            },
            new Card {  Header = "Rose",
                        ImageSrc = "https://bipbap.ru/wp-content/uploads/2017/04/blue_rose_01.jpg",
                        Price = 18.45m,
                        Description = $"This is a royal flower - Beauty Queen"
            },
            new Card {  Header = "Beautifull Flower",
                        ImageSrc = "https://optcvetok.com.ua/img/category/%D1%8B%D0%B0%D1%8B%D0%B0%D1%8B%D0%B0%D0%B2%D1%8B%D0%B2.jpg",
                        Price = 6.45m,
                        Description = $"This is a simple flower for you"
            },
            new Card {  Header = "Rose",
                        ImageSrc = "https://i.pinimg.com/originals/11/2b/74/112b746a2182417b2a947d949798c968.jpg",
                        Price = 16.45m,
                        Description = $"This is the flower for you"
            },
            new Card {  Header = "Beauty",
                        ImageSrc = "https://pbs.twimg.com/profile_images/883859744498176000/pjEHfbdn_400x400.jpg",
                        Price = 5.15m,
                        Description = $"This is the flower for you"
            },
            new Card {  Header = "Rose",
                        ImageSrc = "https://i.pinimg.com/736x/c0/21/69/c02169fd83c62e1fd57d6b52a2d8a7b9.jpg",
                        Price = 15.58m,
                        Description = $"This is the flower for you"
            }
        };
        public IEnumerable<Card> Cards => cards;

        public void AddCard(Card card)
        {
            cards.Add(card);
        }
    }
}
