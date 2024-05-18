using ExFinal.model;
using ExFinal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExFinal.handler
{
    public static class IdScontrinoHandler
    {
        private static int _nextScontrinoId = 1;

        public static int GetNextScontrinoId()
        {
            return _nextScontrinoId++;
        }
    }
}
