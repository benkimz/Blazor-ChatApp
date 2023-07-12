using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace CommsWall.WebApp.Pages.SideViewPages.Settings{
    public class SettingsBase:ComponentBase{
        public  IEnumerable<Settings>Setting{get;set;}
        private void LoadSettings(){
            Settings e1 = new Settings{
            };
        }
    }
}