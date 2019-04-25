using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using FuzzyLogicController;
using FuzzyLogicController.FLC;
using FuzzyLogicController.RuleEngine;
using FuzzyLogicController.MFs;
using StringTools;

namespace FakeNews2019.Pages
{
    public partial class FuzzyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static class FuzzyApp
        {
            public static List<LingVariable> InputVariables;
            public static List<LingVariable> OutputVariables;
            public static List<Rule> Rules;
            public static FLC FuzzyControl;
            public static Config Configuration;

            public static void Initalize()
            {
                InputVariables = new List<LingVariable>();
                OutputVariables = new List<LingVariable>();
                Rules = new List<Rule>();
                Configuration = new Config(ImpMethod.Prod, ConnMethod.Min);
                Configuration.DefuzzificationType = DefuzzifcationType.ModifiedHeight;
                FuzzyControl = new FLC(Configuration);
            }

            public static void defaultSettings1()
            {
                LingVariable FSS = new LingVariable("FSS", VarType.Input);
                FSS.setRange(0, 35);
                FSS.addMF(new Trapmf("Low", -10, 0, 10, 15));
                FSS.addMF(new Trapmf("Medium", 10, 15, 25, 30));
                FSS.addMF(new Trapmf("High", 25, 30, 35, 40));

                LingVariable BSS = new LingVariable("BSS", VarType.Input);
                BSS.setRange(0, 65);
                BSS.addMF(new Trapmf("Low", -10, 0, 20, 40));
                BSS.addMF(new Trimf("Medium", 20, 40, 60));
                BSS.addMF(new Trapmf("High", 40, 60, 65, 70));

                FuzzyApp.InputVariables.Add(FSS);
                FuzzyApp.InputVariables.Add(BSS);

                //output
                LingVariable Speed = new LingVariable("Speed", VarType.Output);
                Speed.setRange(10, 70);
                Speed.addMF(new Trimf("Low", 20, 30, 40));
                Speed.addMF(new Trimf("Medium", 40, 50, 55));
                Speed.addMF(new Trimf("High", 55, 60, 70));

                LingVariable Steer = new LingVariable("Steer", VarType.Output);
                Steer.setRange(-180, 180);
                Steer.addMF(new Trimf("Right", -180, -93, -40));
                Steer.addMF(new Trimf("Zero", -40, 0, 40));
                Steer.addMF(new Trimf("Left", 40, 90, 180));

                FuzzyApp.OutputVariables.Add(Speed);
                FuzzyApp.OutputVariables.Add(Steer);

                //Rules
                #region Rules init
                List<RuleItem> rule1in = new List<RuleItem>();
                List<RuleItem> rule1out = new List<RuleItem>();
                List<RuleItem> rule2in = new List<RuleItem>();
                List<RuleItem> rule2out = new List<RuleItem>();
                List<RuleItem> rule3in = new List<RuleItem>();
                List<RuleItem> rule3out = new List<RuleItem>();
                List<RuleItem> rule4in = new List<RuleItem>();
                List<RuleItem> rule4out = new List<RuleItem>();
                List<RuleItem> rule5in = new List<RuleItem>();
                List<RuleItem> rule5out = new List<RuleItem>();
                List<RuleItem> rule6in = new List<RuleItem>();
                List<RuleItem> rule6out = new List<RuleItem>();
                List<RuleItem> rule7in = new List<RuleItem>();
                List<RuleItem> rule7out = new List<RuleItem>();
                List<RuleItem> rule8in = new List<RuleItem>();
                List<RuleItem> rule8out = new List<RuleItem>();
                #endregion

                //Rule 8 in out
                rule8in.AddRange(new RuleItem[2] { new RuleItem("FSS", "Low"), new RuleItem("BSS", "High") });
                rule8out.AddRange(new RuleItem[2] { new RuleItem("Speed", "High"), new RuleItem("Steer", "Zero") });

                //rule 7 in out
                rule7in.AddRange(new RuleItem[2] { new RuleItem("FSS", "Low"), new RuleItem("BSS", "Medium") });
                rule7out.AddRange(new RuleItem[2] { new RuleItem("Speed", "Medium"), new RuleItem("Steer", "Left") });

                //rule 6 in out
                rule6in.AddRange(new RuleItem[2] { new RuleItem("FSS", "Low"), new RuleItem("BSS", "Low") });
                rule6out.AddRange(new RuleItem[2] { new RuleItem("Speed", "Low"), new RuleItem("Steer", "Left") });

                //rule 5 in out
                rule5in.AddRange(new RuleItem[2] { new RuleItem("FSS", "Medium"), new RuleItem("BSS", "Low") });
                rule5out.AddRange(new RuleItem[2] { new RuleItem("Speed", "Medium"), new RuleItem("Steer", "Left") });

                //Rule 4 in out
                rule4in.AddRange(new RuleItem[2] { new RuleItem("FSS", "Medium"), new RuleItem("BSS", "High") });
                rule4out.AddRange(new RuleItem[2] { new RuleItem("Speed", "Medium"), new RuleItem("Steer", "Right") });

                //rule 3 in out
                rule3in.AddRange(new RuleItem[2] { new RuleItem("FSS", "High"), new RuleItem("BSS", "Low") });
                rule3out.AddRange(new RuleItem[2] { new RuleItem("Speed", "Low"), new RuleItem("Steer", "Right") });

                //rule 2 in out
                rule2in.AddRange(new RuleItem[2] { new RuleItem("FSS", "High"), new RuleItem("BSS", "Medium") });
                rule2out.AddRange(new RuleItem[2] { new RuleItem("Speed", "Medium"), new RuleItem("Steer", "Right") });

                //rule 1 in out
                rule1in.AddRange(new RuleItem[2] { new RuleItem("FSS", "High"), new RuleItem("BSS", "High") });
                rule1out.AddRange(new RuleItem[2] { new RuleItem("Speed", "High"), new RuleItem("Steer", "Zero") });

                List<Rule> rules = new List<Rule>();
                FuzzyApp.Rules.Add(new Rule(rule1in, rule1out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule2in, rule2out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule3in, rule3out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule4in, rule4out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule5in, rule5out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule6in, rule6out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule7in, rule7out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule8in, rule8out, Connector.And));

            }

            public static void defaultSettings2()
            {
                // Inputs
                LingVariable X1 = new LingVariable("X1", VarType.Input);
                X1.setRange(0, 35);
                X1.addMF(new Trapmf("Low", -10, 0, 10, 15));
                X1.addMF(new Trapmf("Medium", 10, 15, 25, 30));
                X1.addMF(new Trapmf("High", 25, 30, 35, 40));

                LingVariable X2 = new LingVariable("X2", VarType.Input);
                X2.setRange(0, 65);
                X2.addMF(new Trapmf("Low", -10, 0, 20, 41));
                X2.addMF(new Trimf("Medium", 20, 41, 60));
                X2.addMF(new Trapmf("High", 41, 60, 65, 70));

                FuzzyApp.InputVariables.Add(X1);
                FuzzyApp.InputVariables.Add(X2);

                //Output
                LingVariable Y1 = new LingVariable("Y1", VarType.Output);
                Y1.setRange(0, 100);
                Y1.addMF(new Trapmf("Low", 10, 20, 30, 40));
                Y1.addMF(new Trapmf("Medium", 40, 50, 60, 70));
                Y1.addMF(new Trapmf("High", 70, 80, 90, 100));

                FuzzyApp.OutputVariables.Add(Y1);

                //Rules
                List<RuleItem> rule1in = new List<RuleItem>();
                List<RuleItem> rule1out = new List<RuleItem>();
                List<RuleItem> rule2in = new List<RuleItem>();
                List<RuleItem> rule2out = new List<RuleItem>();
                List<RuleItem> rule3in = new List<RuleItem>();
                List<RuleItem> rule3out = new List<RuleItem>();
                List<RuleItem> rule4in = new List<RuleItem>();
                List<RuleItem> rule4out = new List<RuleItem>();
                List<RuleItem> rule5in = new List<RuleItem>();
                List<RuleItem> rule5out = new List<RuleItem>();
                List<RuleItem> rule9in = new List<RuleItem>();
                List<RuleItem> rule9out = new List<RuleItem>();

                rule1in.AddRange(new RuleItem[2] { new RuleItem("X1", "Low"), new RuleItem("X2", "Low") });
                rule1out.AddRange(new RuleItem[1] { new RuleItem("Y1", "High") });

                rule2in.AddRange(new RuleItem[2] { new RuleItem("X1", "Low"), new RuleItem("X2", "Medium") });
                rule2out.AddRange(new RuleItem[1] { new RuleItem("Y1", "Low") });

                rule3in.AddRange(new RuleItem[2] { new RuleItem("X1", "Low"), new RuleItem("X2", "High") });
                rule3out.AddRange(new RuleItem[1] { new RuleItem("Y1", "Medium") });

                rule4in.AddRange(new RuleItem[2] { new RuleItem("X1", "Medium"), new RuleItem("X2", "Low") });
                rule4out.AddRange(new RuleItem[1] { new RuleItem("Y1", "Medium") });

                rule5in.AddRange(new RuleItem[2] { new RuleItem("X1", "Medium"), new RuleItem("X2", "Medium") });
                rule5out.AddRange(new RuleItem[1] { new RuleItem("Y1", "High") });

                rule9in.AddRange(new RuleItem[2] { new RuleItem("X1", "High"), new RuleItem("X2", "High") });
                rule9out.AddRange(new RuleItem[1] { new RuleItem("Y1", "Medium") });

                List<Rule> rules = new List<Rule>();
                FuzzyApp.Rules.Add(new Rule(rule1in, rule1out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule2in, rule2out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule3in, rule3out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule4in, rule4out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule5in, rule5out, Connector.And));
                FuzzyApp.Rules.Add(new Rule(rule9in, rule9out, Connector.And));

            }

            public static LingVariable getVariablebyName(List<LingVariable> variable, String name)
            {
                return variable.Find(delegate (LingVariable n) { return n.Name == name; });
            }

            public static List<double> tokString(String Text)
            {
                List<double> list = new List<double>();
                StringTokenizer tok = new StringTokenizer(Text);
             
               // tok.NewDelim(new char[] { ',' });

                String token;
                do
                {
                    token = tok.nextToken();
                    list.Add(Convert.ToDouble(token));

                } while (tok.hasMoreTokens());

                return list;
            }

        }

    }
}