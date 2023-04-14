using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    public class DataFromFile
    {
        public  User User { get; set; }
        public  List<Customer> customers { get; set; }

        public  List<Owner> owners { get; set; }

        public  List<Deliver> delivers { get; set; }

        public  List<Delivery> deliveries { get; set; }

        public  List<Product> products { get; set; }

        public  List<ProductRating> rates { get; set; }

        public  List<ProductPicture> picture { get; set; }

        public  List<Upload> uploads { get; set; }

        public  List<PickUpProduct> pickUps { get; set; }

        public  List<Order> orders { get; set; }

    }
}
