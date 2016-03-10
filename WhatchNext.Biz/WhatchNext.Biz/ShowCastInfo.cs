using Csla;
using System;

namespace WhatchNext.Biz
{
    [Serializable]
    public class ShowCastInfo : BusinessBase<ShowCastInfo>
    {
        public static readonly PropertyInfo<string> CharacterProperty = RegisterProperty<string>(c => c.Character);
        public string Character
        {
            get { return GetProperty(CharacterProperty); }
            private set { LoadProperty(CharacterProperty, value); }
        }

        public static readonly PropertyInfo<string> PersonNameProperty = RegisterProperty<string>(c => c.PersonName);
        public string PersonName
        {
            get { return GetProperty(PersonNameProperty); }
            private set { LoadProperty(PersonNameProperty, value); }
        }


    }
}