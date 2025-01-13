using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galette.Class
{
    internal class GaletteManager
    {
        private ParticipantManager participantManager;
        private Randomizer randomizer;

        public GaletteManager()
        {
            participantManager = new ParticipantManager();
            randomizer = new Randomizer();
        }
        public void Start()
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("\n\n");
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║        TIRAGE AU SORT DE LA        ║");
            Console.WriteLine("║             GALETTE                ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine("\r\n               |))    |))\r\n .             |  )) /   ))\r\n \\\\   ^ ^      |    /      ))\r\n  \\\\(((  )))   |   /        ))\r\n   / G    )))  |  /        ))\r\n  |o  _)   ))) | /       )))\r\n   --' |     ))`/      )))\r\n    ___|              )))\r\n   / __\\             ))))`()))\r\n  /\\@   /             `(())))\r\n  \\/   /  /`_______/\\   \\  ))))\r\n       | |          \\ \\  |  )))\r\n       | |           | | |   )))\r\n       |_@           |_|_@    ))\r\n      /_/           /_/_/\r\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ResetColor();
            Console.ReadKey();

            // Passer au menu principal
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1. Ajouter des participants");
            Console.WriteLine("2. Commencer la galette");
            Console.WriteLine("3. Quitter");
            Console.Write("Votre choix : ");
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    AddParticipants();
                    break;
                case "2":
                    StartGalette();
                    break;
                case "3":
                    Console.WriteLine("Au revoir !");
                    break;
                default:
                    Console.WriteLine("Choix invalide. Appuyez sur une touche pour réessayer.");
                    Console.ReadKey();
                    ShowMenu();
                    break;
            }
        }

        private void StartGalette()
        {
            if (participantManager.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Aucun participant ajouté. Ajoutez des participants d'abord.");
                Console.WriteLine("Appuyez sur une touche pour revenir au menu.");
                Console.ResetColor();
                Console.ReadKey();
                ShowMenu();
                return;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("🎉 Début de la galette des rois 🎉");
            Console.ResetColor();
     
            string coupeur = participantManager.GetRandomParticipant(randomizer);
            Console.WriteLine($"Le coupeur de la galette est : {coupeur}!");
            Console.WriteLine("couteau couteau couteau");

          

            while (participantManager.HasParticipants())
            {
                string destinataire = participantManager.RemoveRandomParticipant(randomizer);

                Console.WriteLine("Part pour : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($" {destinataire}");
                Console.ResetColor();

            }
            string feve = participantManager.GetRandomParticipant(randomizer);

            Console.WriteLine("Toutes les parts ont été distribuées !");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" {feve} a trouvé la fève  !");
            Console.WriteLine("\r\n      <>              \r\n    .::::.             \r\n@\\\\/W\\/\\/W\\//@         \r\n \\\\/^\\/\\/^\\//     \r\n  \\_O_<>_O_/\r\n");
            Console.WriteLine($" {feve} est le boss king !");
            Console.ResetColor();

            Console.WriteLine("Appuyez sur une touche pour revenir au menu.");
            Console.ReadKey();
            ShowMenu();
        }

        private void AddParticipants()
        {
            Console.Clear();
            Console.WriteLine("Ajoutez les prénoms des participants (tapez 'fin' pour arrêter) :");

            string prenom;
            do
            {
                Console.Write("Prénom : ");
                prenom = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(prenom) && prenom.ToLower() != "fin")
                {
                    participantManager.AddParticipant(prenom);
                    Console.WriteLine($"{prenom} a été ajouté !");
                }
            } while (prenom.ToLower() != "fin");

            Console.WriteLine("Participants ajoutés avec succès !");
            Console.WriteLine("Appuyez sur une touche pour revenir au menu.");
            Console.ReadKey();
            ShowMenu();
        }
    }
}
