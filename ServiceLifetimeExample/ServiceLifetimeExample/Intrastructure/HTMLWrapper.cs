using System.Text;
using System.Web;

namespace ServiceLifetimeExample.Intrastructure
{
    public static class HTMLWrapper
    {
        public static string NL => Environment.NewLine;

        public static string HTMLEncode(string text)
        {
            return HttpUtility.HtmlEncode(text);
        }

        public static string GetElement(string tagname, string content)
        {
            StringBuilder sb = new StringBuilder("<");
            sb.Append(tagname);
            sb.Append(">");
            sb.Append(HTMLEncode(content));
            sb.Append("</");
            sb.Append(tagname);
            sb.Append(">");
            return sb.ToString();
        }

        public static string Get_td(string content)
        {
            return GetElement("td", content);
        }
        public static string Get_th(string content)
        {
            return GetElement("th", content);
        }


        public static string ToHtmlTable<T>(this IEnumerable<T> enums)
        {
            var html = new StringBuilder();
            if (enums!=null)
            {
                var type = typeof(T);
                var props = type.GetProperties();
                html.Append("<table>");

            //Header
            html.Append("<thead><tr>");
                foreach (var p in props)
                    html.Append("<th>" + p.Name + "</th>");
                    html.Append("</tr></thead>");

            //Body
            html.Append("<tbody>");
            foreach (var e in enums)
            {
                html.Append("<tr>");
                props.Select(s => s.GetValue(e)).ToList().ForEach(p => {
                html.Append("<td>" + HTMLEncode($"{p}") + "</td>");
                });
                html.Append("</tr>");
            }

                html.Append("</tbody>");
                html.Append("</table>");
            }
                return html.ToString();
        }
        
    }
}
