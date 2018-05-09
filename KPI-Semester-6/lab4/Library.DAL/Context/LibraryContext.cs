using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Library.DAL.Entities;

namespace Library.DAL.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryContext")
        {
            Database.SetInitializer<LibraryContext>(new LibraryDbInitializer());
        }
       
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public class LibraryDbInitializer : DropCreateDatabaseAlways<LibraryContext>
        {
            protected override void Seed(LibraryContext db)
            {
                string[] FirstNames = new string[] { "Willis", "Eugenio", "Darell", "Wendell",
                    "Johnnie", "Hugh", "Denis", "Wallace", "Randolph", "Ricky", "Esteban",
                    "Leonard", "Bryon", "Melvin", "Sidney", "Jarvis", "Fritz", "Eloy",
                    "Jacinto", "Refugio", "Leo", "Dana", "Santiago", "Roderick", "Edwin",
                    "Scott", "Taylor", "Mervin", "Vincent", "Donnie", "Vern", "Rubin",
                    "Santos", "Dominic", "Antoine", "Murray", "Ulysses", "August", "Rickie",
                    "Man", "Grady", "Stan", "Vincenzo", "Marty", "Hosea", "Malik", "Franklyn",
                    "Pierre", "Sergio", "Calvin","Bibi", "Shonna", "Kaila", "Keiko", "Jodie",
                    "Trisha", "Alejandra", "Lenna", "Genesis", "Dina", "Laurel", "Cierra",
                    "Trudy", "Pricilla", "Lennie", "Cordie", "Roxie", "Janis", "Georgianna",
                    "Julietta", "Lucretia", "Karlene", "Janett", "Palmira", "Hermina", "Wendi",
                    "Tangela", "Zita", "Ethel", "Melissa", "Eliz", "Lillie", "Tempie", "Bambi",
                    "Tynisha", "Zenia", "Aline", "Alisa", "Tandra", "Herminia", "Jo",
                    "Roseline", "Leoma", "Shakira", "Chastity", "Annabelle", "Donya",
                    "Elizabet", "Ashlyn", "Goldie" };
                string[] LastNames = new string[] { "Smith", "Johnson", "Williams", "Jones",
                    "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson",
                    "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia",
                    "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", "Walker",
                    "Hall", "Allen", "Young", "Hernandez", "King", "Wright", "Lopez", "Hill",
                    "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter",
                    "Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker",
                    "Evans", "Edwards", "Collins", "Stewart", "Sanchez", "Morris", "Rogers",
                    "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey", "Rivera", "Cooper",
                    "Richardson", "Cox", "Howard", "Ward", "Torres", "Peterson", "Gray",
                    "Ramirez", "James", "Watson", "Brooks", "Kelly", "Sanders", "Price",
                    "Bennett", "Wood", "Barnes", "Ross", "Henderson", "Coleman", "Jenkins",
                    "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores", "Washington",
                    "Butler", "Simmons", "Foster", "Gonzales", "Bryant", "Alexander", "Russell",
                    "Griffin", "Diaz", "Hayes", "Myers", "Ford", "Hamilton", "Graham",
                    "Sullivan", "Wallace", "Woods", "Cole", "West" };
                string[] Genres = new string[] { "Biochemistry", "Chemical Engineering", "Computer Science",
                    "Engineering", "Neuroscience", "Energy", "Finance", "Social Sciences" };
                string[] BookNames = new string[] { "Time and Methods in Environmental Interfaces Modelling",
                    "New Aspects of Meat Quality", "Biology and Engineering of Stem Cell Niches",
                    "Nitric Oxide Donors", "Purification of Laboratory Chemicals (Eighth Edition)",
                    "Certifiable Software Applications 2", "Microforming Technology",
                    "Materials for a Healthy, Ecological and Sustainable Built Environment",
                    "Solidification and Solid-State Transformations of Metals and Alloys",
                    "Nanostructures for Drug Delivery", "Nanocharacterization Techniques",
                    "Development of Biodiesel-Resistant Nitrile Rubber Compositions",
                    "Essentials of Neuroanesthesia",
                    "Reproductive and Developmental Toxicology (Second Edition)",
                    "Japanese Kampo Medicines for the Treatment of Common Diseases: Focus on Inflammation",
                    "Personality Development Across the Lifespan",
                    "Teaching Information Literacy in Higher Education",
                    "Digital Disruption and Electronic Resource Management in Libraries",
                    "Nanoencapsulation Technologies for the Food and Nutraceutical Industries",
                    "Viroids and Satellites", "New Health Systems",
                    "Recrystallization and Related Annealing Phenomena (Third Edition)",
                    "Agile Energy Systems (Second Edition)", "Intelligence in Energy",
                    "Chemical Engineering Process Simulation", "Advanced Gear Manufacturing and Finishing",
                    "RCS Synthesis for Chipless RFID",
                    "Elastic, Plastic and Yield Design of Reinforced Structures",
                    "Decision-Making Management", "Saliva Protection and Transmissible Diseases",
                    "Biomedical Composites (Second Edition)", "Biomaterials",
                    "Nanotechnology Methods for Neurological Diseases and Brain Tumors",
                    "Antiphospholipid Syndrome in Systemic Autoimmune Diseases",
                    "Chemical Contaminants and Residues in Food (Second Edition)",
                    "Nutrients in Dairy and Their Implications for Health and Disease",
                    "Ethical Challenges in Oncology", "Liquid Chromatography (Second Edition)",
                    "Liquid Chromatography (Second Edition)", "Marine Geo-Hazards in China",
                    "Low-Rank Coals for Power Generation, Fuel and Chemical Production",
                    "Bioenergy Systems for the Future", "Boiling",
                    "Biomedical Engineering in Gastrointestinal Surgery",
                    "Electronics Explained (Second Edition)", "Low-Rank Models in Visual Analysis",
                    "Industrial Piping and Equipment Estimating Manual",
                    "Handbook of Investors' Behavior During Financial Crises",
                    "Milestones in Immunology", "Characterization of Polymeric Biomaterials",
                    "Micro and Nano Fibrillar Composites (MFCs and NFCs) from Polymer Blends",
                    "Antimicrobial Nanoarchitectonics", "The Rewiring Brain",
                    "Veterinary Toxicology for Australia and New Zealand",
                    "Application of New Cybernetics in Physics",
                    "Gluten-Free Ancient Grains", "Fatty Acids", "Genetically Engineered Foods",
                    "Kent's Technology of Cereals (Fifth Edition)", "Animals and Human Society",
                    "Innovative Technologies for Food Preservation", "Organosilicon Compounds",
                    "Electrical Submersible Pumps Manual (Second Edition)",
                    "High-Performance Apparel",
                    "Basic Finite Element Method as Applied to Injury Biomechanics",
                    "Construction Delays (Third Edition)", "Cellular Internet of Things",
                    "Reliability of High-Power Mechatronic Systems 1",
                    "Environmental Geochemistry (Second Edition)", "Floods", "Portfolio Diversification",
                    "Urban Emergency Management", "Advanced Characterization and Testing of Textiles",
                    "Functionalised Cardiovascular Stents",
                    "Advances in Laser Materials Processing (Second Edition)", "Biopolymer Grafting",
                    "Handbook of Antimicrobial Coatings", "Galois Fields and Galois Rings Made Easy",
                    "Neuroepidemiology in Tropical Health", "Arachnoid Cysts", "Arachnoid Cysts",
                    "Mutagenicity: Assays and Applications", "An Introduction to Bibliometrics",
                    "Studies in Natural Products Chemistry", "Unconventional Oilseeds and Oil Sources",
                    "Hormone Metabolism and Signaling in Plants", "Medical Biochemistry",
                    "Lung Epithelial Biology in the Pathogenesis of Pulmonary Disease",
                    "Congenital Adrenal Hyperplasia", "Electrochemistry of Dihydroxybenzene Compounds",
                    "Research Methods for Cyber Security", "Kappa Distributions",
                    "Rigid Body Dynamics for Space Applications",
                    "Pipeline Integrity Handbook (Second Edition)",
                    "Risk and Return for Regulated Industries", "Nanodiamonds",
                    "Fundamentals of Quantum Mechanics (Third Edition)" };

                Random random = new Random();

                int n = random.Next(30, 40);
                for (int i = 0; i < n; i++)
                {
                    db.Authors.Add(new Author
                    {
                        FirstName = FirstNames[random.Next(0, FirstNames.Length)],
                        LastName = LastNames[random.Next(0, LastNames.Length)]
                    });
                }
                db.SaveChanges();

                for (int i = 0; i < n; i++)
                {
                    db.Users.Add(new User
                    {
                        FirstName = FirstNames[random.Next(0, FirstNames.Length)],
                        LastName = LastNames[random.Next(0, LastNames.Length)],
                        Quantity = 0
                    });
                }
                db.SaveChanges();
                for (int i = 0; i < Genres.Length; i++)
                { db.Genres.Add(new Genre { Name = Genres[i] }); }
                db.SaveChanges();
                n = random.Next(10, 20);
                for (int i = 0; i < n; i++)
                {
                    db.Books.Add(new Book
                    {
                        Name = BookNames[random.Next(0, BookNames.Length)],
                        GenreID = random.Next(1, Genres.Length + 1),
                        PublishDate = DateTime.Now
                    });
                }
                db.SaveChanges();
            }
        }
    }
}