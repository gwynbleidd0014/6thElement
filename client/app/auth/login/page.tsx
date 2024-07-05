import LoginComp from "@/components/Login/LoginComp";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default function Login() {
  const token = cookies().get("token");

  if (token) {
    redirect("/dashboard/learn");
  }
  return <LoginComp />;
}
