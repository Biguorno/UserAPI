namespace UserAPI.DTO
{
    public class UserDTO
    {

        public int Uti_Id { get; set; }
        public string? Uti_Nom { get; set; }
        public string? Uti_Prenom { get; set; }
        public string? Uti_Adresse { get; set; }
        public string? Uti_Ville { get; set; }
        public string? Uti_Cp { get; set; }
        public string? Uti_Telephone { get; set; }
        public string? Uti_Email { get; set; }
        public string? Uti_Mdp { get; set; } // voir hash du Mdp (pas le mettre en clair)
        public string? Uti_TypeUtil { get; set; } // définit si l'utilisateur est Administateur, Comptable, Client ou Livreur

    }
}
