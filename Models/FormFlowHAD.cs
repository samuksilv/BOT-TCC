using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;

namespace Microsoft.Bot.Sample.FormBot
{
   
 	[Serializable]
    [Template(TemplateUsage.NotUnderstood, "Eu não entendi o termo: \"{0}\", poderia explicar de novo?","Desculpe, eu não entendi \"{0}\". Por favor informe novamente." )]
    public class FormFlowHAD
    {
        #region Properties
        public string ID { get; set; }

        [Prompt("Qual o seu nome?")]
        public string NOME { get; set; }

        
        [Prompt("Qual a sua idade?")]
        [Numeric(1, 500)]
        public int IDADE { get; set; }

        [Prompt("Qual seu sexo?{||}")]
        public sexo? SEXO { get; set; }

        //[Prompt("Por favor responda as proximas perguntas com  sinceridade...")]
        //public string ApresentacaoQuestionario { get; set; }

        [Prompt("Você se sente tensa (o) ou contraída (o)?{||}")]
        public tensao? TENSAO { get; set; }

        [Prompt("Você sente que gosto das mesmas coisas de antes?{||}")]
        public interrese? INTERESSE { get; set; }

        [Prompt("Você sento uma espécie de medo, como se alguma coisa ruim fosse acontecer?{||}")]
        public medo? MEDO { get; set; }

        [Prompt("Dá risadas e se diverte quando vê coisas engraçadas?{||}")]
        public humor? HUMOR { get; set; }

        [Prompt("Está com a cabeça cheia de preocupações?{||}")]
        public preocupacao? PREOCUPACAO { get; set; }

        [Prompt("Se sente alegre?{||}")]
        public alegria? ALEGRIA { get; set; }

        [Prompt("Consegue ficar sentada(o) à vontade e se sentir relaxada(o)?{||}")]
        public relaxado? RELAXADO { get; set; }

        [Prompt("Se sente lenta (o) para pensar e fazer coisas?{||}")]
        public pensamento? PENSAMENTO { get; set; }

        [Prompt("Tem uma sensação ruim de medo, como um frio na barriga ou um aperto no estômago?{||}")]
        public sensacaoruim? SENSACAORUIM { get; set; }

        [Prompt("Você sente que perdeu o interesse em cuidar da própria aparência?{||}")]
        public aparencia? APARENCIA { get; set; }

        [Prompt("Você se sente inquieta (o), como se não pudesse ficar parada (o) em lugar nenhum?{||}")]
        public inquieto? INQUIETO { get; set; }

        [Prompt("Fica animada (o) esperando as coisas boas que estão por vir?{||}")]
        public animacao? ANIMACAO { get; set; }

        [Prompt("De repente, tem a sensação de entrar em pânico?{||}")]
        public panico? PANICO { get; set; }

        [Prompt("Consegue sentir prazer quando assiste a um bom programa de televisão, de rádio ou quando lê alguma coisa? {||} ")]
        public prazer? PRAZER { get; set; }

        #endregion

        #region enums
        public enum sexo
        {
            Masculino,
            Feminino,
        }
        public enum tensao
        {
            [Terms("a maior parte do tempo")]
            [Describe("a maior parte do tempo")]
            option1=3,
            [Terms("boa parte do tempo")]
            [Describe("boa parte do tempo")]
            option2 = 2,
            [Terms("de vez em quando")]
            [Describe("de vez em quando")]
            option3 = 1,
            [Terms("nunca")]
            [Describe("nunca")]
            option4 = 0
        }

        public enum interrese
        {
            [Terms("sim, do mesmo jeito que antes")]
            [Describe("sim, do mesmo jeito que antes")]
            option1 = 0,
            [Terms("não tanto quanto antes")]
            [Describe("não tanto quanto antes")]
            option2 = 1,
            [Terms("só um pouco")]
            [Describe("só um pouco")]
            option3 = 2,
            [Terms(" já não consigo ter prazer em nada")]
            [Describe(" já não consigo ter prazer em nada")]
            option4 = 3           
        }

        public enum medo
        {
            [Terms("sim, de jeito muito forte")]
            [Describe("sim, de jeito muito forte")]
            option1 = 3,
            [Terms("sim, mas não tão forte")]
            [Describe("sim, mas não tão forte")]
            option2 = 2,
            [Terms("um pouco, mas isso não me preocupa")]
            [Describe("um pouco, mas isso não me preocupa")]
            option3 = 1,
            [Terms("não sinto nada disso")]
            [Describe("não sinto nada disso")]
            option4 = 0

        }

        public enum humor
        {
            [Terms("sim, do mesmo jeito que antes")]
            [Describe("sim, do mesmo jeito que antes")]
            option1 = 0,
            [Terms("atualmente um pouco menos")]
            [Describe("atualmente um pouco menos")]
            option2 = 1,
            [Terms("atualmente bem menos")]
            [Describe("atualmente bem menos")]
            option3 = 2,
            [Terms("não consigo mais")]
            [Describe("não consigo mais")]
            option4 = 3
        }

        public enum preocupacao
        {
            [Terms("a maior parte do tempo")]
            [Describe("a maior parte do tempo")]
            option1 = 3,
            [Terms("boa parte do tempo")]
            [Describe("boa parte do tempo")]
            option2 = 2,
            [Terms("de vez em quando")]
            [Describe("de vez em quando")]
            option3 = 1,
            [Terms("raramente")]
            [Describe("raramente")]
            option4 = 0
        }

        public enum alegria
        {
            [Terms("nunca")]
            [Describe("nunca")]
            option1 = 3,
            [Terms("poucas vezes")]
            [Describe("poucas vezes")]
            option2 = 2,
            [Terms("muitas vezes")]
            [Describe("muitas vezes")]
            option3 = 1,
            [Terms("a maior parte do tempo")]
            [Describe("a maior parte do tempo")]
            option4 = 0
        }

        public enum relaxado
        {
            [Terms("sim, quase sempre")]
            [Describe("sim, quase sempre")]
            option1 = 0,
            [Terms("muitas vezes")]
            [Describe("muitas vezes")]
            option2 = 1,
            [Terms("poucas vezes")]
            [Describe("poucas vezes")]
            option3 = 2,
            [Terms("nunca")]
            [Describe("nunca")]
            option4 = 3
        }

        public enum pensamento
        {
            [Terms("quase sempre")]
            [Describe("quase sempre")]
            option1 = 3,
            [Terms("muitas vezes")]
            [Describe("muitas vezes")]
            option2 = 2,
            [Terms("poucas vezes")]
            [Describe("poucas vezes")]
            option3 = 1,
            [Terms("nunca")]
            [Describe("nunca")]
            option4 = 0
        }

        public enum sensacaoruim
        {
            [Terms("nunca")]
            [Describe("nunca")]
            option1 = 0,
            [Terms("de vez em quando")]
            [Describe("de vez em quando")]
            option2 = 1,
            [Terms("muitas vezes")]
            [Describe("muitas vezes")]
            option3= 2,
            [Terms("quase sempre")]
            [Describe("quase sempre")]
            option4 = 3
        }

        public enum aparencia
        {
            [Terms("completamente")]
            [Describe("completamente")]
            option1 = 3,
            [Terms("não estou mais me cuidando como deveria")]
            [Describe("não estou mais me cuidando como deveria")]
            option2 = 2,
            [Terms("talvez não tanto quanto antes")]
            [Describe("talvez não tanto quanto antes")]
            option3 = 1,
            [Terms("me cuido do mesmo jeito que antes")]
            [Describe("me cuido do mesmo jeito que antes")]
            option4 = 0
        }

        public enum inquieto
        {
            [Terms("sim, demais")]
            [Describe("sim, demais")]
            option1 = 3,
            [Terms("bastante")]
            [Describe("bastante")]
            option2 = 2,
            [Terms("um pouco")]
            [Describe("um pouco")]
            option3 = 1,
            [Terms("não me sinto assim")]
            [Describe("não me sinto assim")]
            option4 = 0
        }

        public enum animacao
        {
            [Terms("do mesmo jeito que antes")]
            [Describe("do mesmo jeito que antes")]
            option1 = 0,
            [Terms("um pouco menos que antes")]
            [Describe("um pouco menos que antes")]
            option2 = 1,
            [Terms("bem menos que antes")]
            [Describe("bem menos que antes")]
            option3 = 2,
            [Terms("quase nunca")]
            [Describe("quase nunca")]
            option4 = 3
        }

        public enum panico
        {
            [Terms("quase todo momento")]
            [Describe("quase todo momento")]
            option1 = 3,
            [Terms("um pouco menos que antes")]
            [Describe("um pouco menos que antes")]
            option2 = 2,
            [Terms("bem menos do que antes")]
            [Describe("bem menos do que antes")]
            option3 = 1,
            [Terms("quase nunca")]
            [Describe("quase nunca")]
            option4 = 0
        }
        public enum prazer
        {
            [Terms("quase sempre")]
            [Describe("quase sempre")]
            option1 = 0,
            [Terms("várias vezes")]
            [Describe("várias vezes")]
            option2 = 1,
            [Terms("poucas vezes")]
            [Describe("poucas vezes")]
            option3 = 2,
            [Terms("quase nunca")]
            [Describe("quase nunca")]
            option4 = 3
        }

        public static string EnumsTypeDescription(Enum e)
        {
            FieldInfo fi = e.GetType().GetField(e.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            List<string> descriptions = new List<string>();
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return e.ToString();
            }
        }

        #endregion


        public static IForm<FormFlowHAD> BuildHADForm()
        {
            OnCompletionAsyncDelegate<FormFlowHAD> messagemFinalizacao = async (context, state) =>
            {
                await context.PostAsync("Obrigado por sua atenção e paciência.");
            };

            ActiveDelegate<FormFlowHAD> messagemApresentacaoFormularioHAD = (state) =>
            {
                return state.SEXO.HasValue & !string.IsNullOrEmpty(state.NOME);
            };            

            return new FormBuilder<FormFlowHAD>()
                            .Field(nameof(NOME))
                            .Field(nameof(IDADE))
                            .Field(nameof(SEXO))
                            .Confirm("Por favor, responda as próximas perguntas com sinceridade e atenção...", messagemApresentacaoFormularioHAD)
                            .AddRemainingFields(exclude: new List<string> { "NOME", "SEXO", "IDADE", "ID"})
                            .Confirm("você informou {&} \n{||}?", null,null)
                            .OnCompletion(messagemFinalizacao)
                            .Build();
        }
    }
}
