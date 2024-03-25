using System.Collections.Generic;

namespace Acceler.Models.ViewModels
{
    public class ConversationViewModel
    {
        public User CurrentUser { get; set; }
        public IEnumerable<UserChatViewModel> OtherUsers { get; set; }
    }
}