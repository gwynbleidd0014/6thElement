import SideBar from "@/components/dashboard/Layout/SideBar";

export default async function DashboardLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <>
      <SideBar />
      <main className="xl:ml-[300px]">{children}</main>
    </>
  );
}
