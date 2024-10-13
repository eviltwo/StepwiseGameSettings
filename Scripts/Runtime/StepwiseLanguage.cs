#if LOCALIZATION
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace StepwiseGameSettings
{
    public class StepwiseLanguage : IStepwise
    {
        private IReadOnlyList<Locale> _locales;

        private void CollectLocales()
        {
            if (_locales == null)
            {
                _locales = LocalizationSettings.AvailableLocales.Locales;
            }
        }

        public int GetStepCount()
        {
            CollectLocales();
            return _locales.Count;
        }

        public void SetStep(int step)
        {
            CollectLocales();
            step = Mathf.Clamp(step, 0, _locales.Count - 1);
            LocalizationSettings.SelectedLocale = _locales[step];
        }

        public int GetStep()
        {
            CollectLocales();
            return GetStepByLocaleCode(LocalizationSettings.SelectedLocale.Identifier.Code);
        }

        public int GetStepByLocaleCode(string localeCode)
        {
            CollectLocales();
            for (int i = 0; i < _locales.Count; i++)
            {
                if (_locales[i].Identifier.Code == localeCode)
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetDisplayName(int step)
        {
            CollectLocales();
            return _locales[step].Identifier.CultureInfo.DisplayName;
        }

        public string GetNativeName(int step)
        {
            CollectLocales();
            return _locales[step].Identifier.CultureInfo.NativeName;
        }

        public string GetLocaleCode(int step)
        {
            CollectLocales();
            return _locales[step].Identifier.Code;
        }
    }
}
#endif
