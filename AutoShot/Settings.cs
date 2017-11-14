using System;
using System.Configuration;
using System.IO;

namespace AutoShot
{
    class Settings : ApplicationSettingsBase
    {
        private static Settings instance;

        public static Settings Instance
        {
            get {
                instance = instance ?? new Settings();
                return instance;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        public bool IncludeCursor
        {
            get {
                return Convert.ToBoolean(this["IncludeCursor"]);
            }
            set {
                this["IncludeCursor"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public string SaveDirectory
        {
            get {
                string savedValue = (string)this["SaveDirectory"];
                Console.WriteLine(savedValue);
                if (savedValue != null) {
                    try {
                        new FileInfo(savedValue);
                    } catch (Exception ex) {
                        if (ex is ArgumentException || ex is PathTooLongException || ex is NotSupportedException) {
                            savedValue = null;
                        } else {
                            throw;
                        }
                    }
                }
                return savedValue ??
                    Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                        "AutoShot"
                    );
            }
            set {
                this["SaveDirectory"] = value;
            }
        }

        public string EnsureSaveDirectory()
        {
            if (!Directory.Exists(this.SaveDirectory)) {
                Directory.CreateDirectory(this.SaveDirectory);
            }
            return this.SaveDirectory;
        }
    }
}
