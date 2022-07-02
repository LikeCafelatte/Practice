int T = int.Parse(Console.ReadLine());
List<int[]> fibonacci_list = new List<int[]> ();
        fibonacci_list.Add(new int[] { 0, 1, 0});
        fibonacci_list.Add(new int[] { 1, 0, 1});
for (int i = 0; i < T; i++)
{
    int input = int.Parse(Console.ReadLine());
    fibonacci(input);
    Console.WriteLine(fibonacci_list[input][1] + " " + fibonacci_list[input][2]);
}
int[] fibonacci(int n) {
    if(fibonacci_list.Count() >= n + 1){
        return fibonacci_list[n];
    }
    if (n == 0) {
        return fibonacci_list[n];
    }
    if (n == 1) {
        return fibonacci_list[n];
    }
        fibonacci_list.Add(new int[] { n, fibonacci(n-1)[1] + fibonacci(n-2)[1], fibonacci(n-1)[2] + fibonacci(n-2)[2]});
        return fibonacci_list[n];
        
}