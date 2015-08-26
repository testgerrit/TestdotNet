static void Main(string[] args)
{
 Console.WriteLine("Active Connections");
 Console.WriteLine();
 
 Console.WriteLine("  Proto  Local Address          Foreign Address        State         PID");
 foreach (TcpRow tcpRow in ManagedIpHelper.GetExtendedTcpTable(true))
 {
  Console.WriteLine("  {0,-7}{1,-23}{2, -23}{3,-14}{4}", "TCP", tcpRow.LocalEndPoint, tcpRow.RemoteEndPoint, tcpRow.State, tcpRow.ProcessId);
 
  Process process = Process.GetProcessById(tcpRow.ProcessId);
  if (process.ProcessName != "System")
  {
   foreach (ProcessModule processModule in process.Modules)
   {
    Console.WriteLine("  {0}", processModule.FileName);
   }
 
   Console.WriteLine("  [{0}]", Path.GetFileName(process.MainModule.FileName));
  }
  else
  {
   Console.WriteLine("  -- unknown component(s) --");
   Console.WriteLine("  [{0}]", "System");
  }
 
  Console.WriteLine();
 }
 
 Console.Write("{0}Press any key to continue...", Environment.NewLine);
 Console.ReadKey();
}