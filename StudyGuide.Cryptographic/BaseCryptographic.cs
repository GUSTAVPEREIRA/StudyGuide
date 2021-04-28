﻿namespace StudyGuide.Cryptographic
{
    public abstract class BaseCryptographic
    {        
        public abstract string Encrypt(string password);
        public abstract bool Verify(string password);
    }
}