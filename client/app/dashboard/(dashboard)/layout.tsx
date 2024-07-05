import SideBar from "@/components/dashboard/Layout/SideBar";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default async function DashboardLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  
  const token = cookies().get("token");

  if (!token) {
    redirect("/");
  }

  return (
    <>
      <SideBar />
      <main className="xl:ml-[300px]">{children}</main>
    </>
  );
}
