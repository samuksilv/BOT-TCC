using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Web;

namespace Microsoft.Bot.Sample.FormBot
{

    [Serializable]
    [Template(TemplateUsage.NotUnderstood, "Eu não entendi o termo: \"{0}\", poderia explicar de novo?", "Desculpe, eu não entendi \"{0}\". Por favor informe novamente.")]
    public class FormFlowHAD
    {
        #region Properties       

        [Prompt("Qual o seu nome?")]
        public string NOME { get; set; }

        [Prompt("Qual a sua idade?")]
        [Numeric(1, 500)]
        public int IDADE { get; set; }

        [Prompt("Qual seu sexo?{||}")]
        public SexoEnum? SEXO { get; set; }

        [Prompt("Você se sente tensa(o) ou contraída(o)?{||}")]
        public TensaoEnum? TENSAO { get; set; }

        [Prompt("Você sente que gosto das mesmas coisas de antes?{||}")]
        public InterreseEnum? INTERESSE { get; set; }

        [Prompt("Você sento uma espécie de medo, como se alguma coisa ruim fosse acontecer?{||}")]
        public MedoEnum? MEDO { get; set; }

        [Prompt("Dá risadas e se diverte quando vê coisas engraçadas?{||}")]
        public HumorEnum? HUMOR { get; set; }

        [Prompt("Está com a cabeça cheia de preocupações?{||}")]
        public PreocupacaoEnum? PREOCUPACAO { get; set; }

        [Prompt("Se sente alegre?{||}")]
        public AlegriaEnum? ALEGRIA { get; set; }

        [Prompt("Consegue ficar sentada(o) à vontade e se sentir relaxada(o)?{||}")]
        public RelaxadoEnum? RELAXADO { get; set; }

        [Prompt("Se sente lenta(o) para pensar e fazer coisas?{||}")]
        public PensamentoEnum? PENSAMENTO { get; set; }

        [Prompt("Tem uma sensação ruim de medo, como um frio na barriga ou um aperto no estômago?{||}")]
        public SensacaoRuimEnum? SENSACAORUIM { get; set; }

        [Prompt("Você sente que perdeu o interesse em cuidar da própria aparência?{||}")]
        public AparenciaEnum? APARENCIA { get; set; }

        [Prompt("Você se sente inquieta(o), como se não pudesse ficar parada (o) em lugar nenhum?{||}")]
        public InquietoEnum? INQUIETO { get; set; }

        [Prompt("Fica animada(o) esperando as coisas boas que estão por vir?{||}")]
        public AnimacaoEnum? ANIMACAO { get; set; }

        [Prompt("De repente, tem a sensação de entrar em pânico?{||}")]
        public PanicoEnum? PANICO { get; set; }

        [Prompt("Consegue sentir prazer quando assiste a um bom programa de televisão, de rádio ou quando lê alguma coisa? {||} ")]
        public PrazerEnum? PRAZER { get; set; }

        #endregion

        #region enums
        public enum SexoEnum
        {
            Masculino,
            Feminino,
        }
        public enum TensaoEnum
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
            [Terms("nunca")]
            [Describe("nunca")]
            option4 = 0
        }

        public enum InterreseEnum
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

        public enum MedoEnum
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

        public enum HumorEnum
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

        public enum PreocupacaoEnum
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

        public enum AlegriaEnum
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

        public enum RelaxadoEnum
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

        public enum PensamentoEnum
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

        public enum SensacaoRuimEnum
        {
            [Terms("nunca")]
            [Describe("nunca")]
            option1 = 0,
            [Terms("de vez em quando")]
            [Describe("de vez em quando")]
            option2 = 1,
            [Terms("muitas vezes")]
            [Describe("muitas vezes")]
            option3 = 2,
            [Terms("quase sempre")]
            [Describe("quase sempre")]
            option4 = 3
        }

        public enum AparenciaEnum
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

        public enum InquietoEnum
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

        public enum AnimacaoEnum
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

        public enum PanicoEnum
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

        public enum PrazerEnum
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

        public static string GetMessageOfResonse(object e)
        {
            FieldInfo fi = e.GetType().GetField(e.ToString());
            DescribeAttribute[] attributes = (DescribeAttribute[])fi.GetCustomAttributes(typeof(DescribeAttribute), false);
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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("DADOS DO USUÁRIO: ");
            builder.AppendLine();
            builder.AppendLine($"{nameof(this.NOME)}: \t {this.NOME} ");
            builder.AppendLine($"{nameof(this.IDADE)}: \t {this.IDADE} ");
            builder.AppendLine($"{nameof(this.SEXO)}: \t {this.SEXO} ");
            builder.AppendLine();

            builder.AppendLine($"ANÁLISE DAS RESPOSTAS DE {this.NOME.ToUpper()}:");
            builder.AppendLine();

            builder.AppendLine("Você se sente tensa(o) ou contraída(o)?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.TENSAO)}.\" | Pontos: {((int)this.TENSAO).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Você sente que gosto das mesmas coisas de antes ?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.INTERESSE)}.\" | Pontos: {((int)this.INTERESSE).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Você sento uma espécie de medo, como se alguma coisa ruim fosse acontecer ?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.MEDO)}.\" | Pontos: {((int)this.MEDO).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Dá risadas e se diverte quando vê coisas engraçadas?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.HUMOR)}.\" | Pontos: {((int)this.HUMOR).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Está com a cabeça cheia de preocupações?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.PREOCUPACAO)}.\" | Pontos: {((int)this.PREOCUPACAO).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Se sente alegre?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.ALEGRIA)}.\" | Pontos: {((int)this.ALEGRIA).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Consegue ficar sentada(o) à vontade e se sentir relaxada(o)?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.RELAXADO)}.\" | Pontos: {((int)this.RELAXADO).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Se sente lenta(o) para pensar e fazer coisas?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.PENSAMENTO)}.\" | Pontos: {((int)this.PENSAMENTO).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Tem uma sensação ruim de medo, como um frio na barriga ou um aperto no estômago?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.SENSACAORUIM)}.\" | Pontos: {((int)this.SENSACAORUIM).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Você sente que perdeu o interesse em cuidar da própria aparência?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.APARENCIA)}.\" | Pontos: {((int)this.APARENCIA).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Você se sente inquieta(o), como se não pudesse ficar parada (o) em lugar nenhum?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.INQUIETO)}.\" | Pontos: {((int)this.INQUIETO).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Fica animada(o) esperando as coisas boas que estão por vir?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.ANIMACAO)}.\" | Pontos: {((int)this.ANIMACAO).ToString()}");
            builder.AppendLine();

            builder.AppendLine("De repente, tem a sensação de entrar em pânico?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.PANICO)}.\" | Pontos: {((int)this.PANICO).ToString()}");
            builder.AppendLine();

            builder.AppendLine("Consegue sentir prazer quando assiste a um bom programa de televisão, de rádio ou quando lê alguma coisa?");
            builder.AppendLine($"Resposta : \"{GetMessageOfResonse(this.PRAZER)}.\" | Pontos: {((int)this.PRAZER).ToString()}");
            builder.AppendLine();

            builder.AppendLine();

            int pointsAnsiety = 0;
            pointsAnsiety += (int)this.TENSAO;
            pointsAnsiety += (int)this.MEDO;
            pointsAnsiety += (int)this.PREOCUPACAO;
            pointsAnsiety += (int)this.RELAXADO;
            pointsAnsiety += (int)this.SENSACAORUIM;
            pointsAnsiety += (int)this.INQUIETO;
            pointsAnsiety += (int)this.PANICO;

            int pointsDepression = 0;
            pointsDepression += (int)this.INTERESSE;
            pointsDepression += (int)this.HUMOR;
            pointsDepression += (int)this.ALEGRIA;
            pointsDepression += (int)this.PENSAMENTO;
            pointsDepression += (int)this.APARENCIA;
            pointsDepression += (int)this.ANIMACAO;
            pointsDepression += (int)this.PRAZER;

            builder.AppendLine("RESULTADOS:");
            builder.AppendLine();
            builder.AppendLine();

            builder.AppendLine($"Pontos Ansiedade: ({pointsAnsiety.ToString()}) | Pontos Depressão: ({ pointsDepression.ToString()})");
            builder.AppendLine();

            builder.Append("Ansiedade: ");
            builder.Append((this.SEXO == SexoEnum.Masculino ? "O " : "A " )+ "paciente  " + this.NOME);
            if (pointsAnsiety <= 7)
                builder.Append(" não apresenta indícios de ansiedade.");
            else if (pointsAnsiety >= 8 && pointsAnsiety <= 10)
                builder.AppendLine(" apresenta sinais leves de ansiedade.");
            else if (pointsAnsiety >= 11 && pointsAnsiety <= 14)
                builder.AppendLine(" apresenta sintomas moderados de ansiedade.");
            else if (pointsAnsiety >= 15 && pointsAnsiety <= 21)
                builder.AppendLine(" apresenta sintomas graves de ansiedade.");

            builder.AppendLine();

            builder.Append("Depressão: ");
            builder.Append((this.SEXO == SexoEnum.Masculino ? "O " : "A " )+ "paciente  " + this.NOME);
            if (pointsDepression <= 7)
                builder.Append(" não apresenta indícios de depressão.");
            else if (pointsDepression >= 8 && pointsDepression <= 10)
                builder.AppendLine(" apresenta sinais leves de depressão.");
            else if (pointsDepression >= 11 && pointsDepression <= 14)
                builder.AppendLine(" apresenta sintomas moderados de depressão.");
            else if (pointsDepression >= 15 && pointsDepression <= 21)
                builder.AppendLine(" apresenta sintomas graves de depressão.");

            builder.AppendLine();

            return builder.ToString();
        }

        public static IForm<FormFlowHAD> BuildHADForm()
        {
            OnCompletionAsyncDelegate<FormFlowHAD> messagemFinalizacao = async (context, state) =>
            {
                string data = state.ToString();

                string path = HttpContext.Current.Server.MapPath("~/report");
                path = Path.Combine(path, state.NOME);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = Path.Combine(path, state.NOME + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".txt");

                File.WriteAllText(path, data, Encoding.UTF8);

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
                            .AddRemainingFields(exclude: new List<string> { "NOME", "SEXO", "IDADE", "ID" })
                            //.Confirm("Seus dados estão corretos? {*} }", null, null)
                            .OnCompletion(messagemFinalizacao)
                            .Build();
        }
    }
}
