using System.Collections;

namespace DataTest.Data.Util
{
    public class FunctionUtil
    {
        public static void PrintArrayList(ArrayList arrayList)
        {
            foreach (var item in arrayList)
            {
                Console.Write(item + ",");
            }
        }

        public static ArrayList GetListElementRandom(ArrayList listElement, int quantity)
        {
            if (quantity <= 0 || listElement.Count == 0)
            {
                // Trả về ArrayList trống nếu số lượng yêu cầu là 0 hoặc danh sách ban đầu rỗng
                return new ArrayList();
            }

            // Sử dụng lớp Random để tạo số ngẫu nhiên
            Random random = new Random();

            // Fisher-Yates Shuffle để xáo trộn danh sách
            for (int i = listElement.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = listElement[i];
                listElement[i] = listElement[j];
                listElement[j] = temp;
            }

            // Lấy ra quantity phần tử đầu tiên của danh sách đã xáo trộn
            ArrayList randomElements = new ArrayList(listElement.GetRange(0, Math.Min(quantity, listElement.Count)));

            return randomElements;
        }

    }
}
