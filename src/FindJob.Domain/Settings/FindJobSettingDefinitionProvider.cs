using Volo.Abp.Settings;

namespace FindJob.Settings
{
    public class FindJobSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(FindJobSettings.MySetting1));
        }
    }
}
