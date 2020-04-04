using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPOLAB2
{
    class Polygon
    {
        private Condition[] conditions;

        internal Condition[] Conditions { get => conditions; set => conditions = value; }

        public Polygon(Condition[] conditions)
        {
            this.Conditions = conditions;
        }

        public Condition[] GetPoints()
        {
            return this.Conditions;
        }

        public int getNumberOfEdges()
        {
            return Conditions.Length;
        }

        private bool atLeastOneCriticalChecked(List<Condition> conditions, Point point)
        {
            if (conditions.Count == 0) { return true; }
            foreach (Condition c in conditions)
            {
                if (c.Line.pointPositionAboutLine(point) == c.Position || c.Line.pointPositionAboutLine(point) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool allBasicChecked(List<Condition> conditions, Point point)
        {
            foreach (Condition c in conditions)
            {
                if (c.Line.pointPositionAboutLine(point) == c.Position)
                {
                    continue;
                }
                else if (c.Line.pointPositionAboutLine(point) == 0) {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private List<Condition> getAllCriticalConditions()
        {
            List<Condition> result = new List<Condition>();
            foreach (Condition c in conditions)
            {
                if (c.IsCritical)
                {
                    result.Add(c);
                }
            }
            return result;
        }

        private List<Condition> getAllBasicConditions()
        {
            List<Condition> result = new List<Condition>();
            foreach (Condition c in conditions)
            {
                if (!c.IsCritical)
                {
                    result.Add(c);
                }
            }
            return result;
        }

        public bool isDotInsidePolygonSpecialInspection(Point point)
        {
            List<Condition> basic = getAllBasicConditions();
            List<Condition> critical = getAllCriticalConditions();

            if (allBasicChecked(basic, point) && atLeastOneCriticalChecked(critical, point)) {
                return true;
            }
            return false;
        }

        public bool dotIsInPolygon(Point point)
        {
            foreach (Condition c in Conditions)
            {
                if (c.Line.pointPositionAboutLine(point) != c.Position)
                {
                    return false;
                }
                else if (c.Line.pointPositionAboutLine(point) == c.Position)
                {
                    continue;
                }
                else if (c.Line.pointPositionAboutLine(point) == 0)
                {
                    return true;
                }
            }
            return true;
        }
    }
}
