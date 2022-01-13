﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.ViewModels
{
    // ViewModell réteg
    // A megjeleítendő adatokat kell megadni itt vmi
    class ProgramInfoViewModel
    {
        private ProgramInfo programInfo;
        public string Version 
        { 
            get
            {
                return programInfo.Version.ToString();
            }
            set
            {
                Version = value;
            }
        }
        public string Title
        {
            get
            {
                return programInfo.Title.ToString();
            }
            set
            {
                Title = value;
            }
        }
        public string Description
        {
            get
            {
                return programInfo.Description.ToString();
            }
            set
            {
                Version = value;
            }
        }
        public string Company
        {
            get
            {
                return programInfo.Company.ToString();
            }
            set
            {
                Version = value;
            }
        }
        public ProgramInfoViewModel()
        {
            programInfo = new ProgramInfo();
        }
    }
}