﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 *	
 *  
 *
 *	by Xuanyi
 *
 */

namespace MoleMole
{
	public class UIType {

        private string _path;

        public string Path { get; private set; }

        private string _name;

        public string Name { get; private set; }

        public UIType(string path)
        {
            Path = path;
            Name = path.Substring(path.LastIndexOf('/') + 1);
        }

        public override string ToString()
        {
            return string.Format("path : {0} name : {1}", Path, Name);
        }

        public static readonly UIType MainMenu = new UIType("View/MainMenuView");
        public static readonly UIType OptionMenu = new UIType("View/OptionMenuView");
    }
}
