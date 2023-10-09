namespace ML.SDK.DM60X.Model
{
    public class DM60XFeedbackModel
    {
        public bool TriggerConfFeedback { get; set; }
        public bool NetworkConfFeebback { get; set; }
        public bool  SymbolicConfFeebback { get; set; }
        public bool RebootFeedback { get; set; }
        public bool ResetAndRebootFeedback { get; set; }
    }
}
