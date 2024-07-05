import SignupComp from "@/components/Signup/SignupComp";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default function Signup() {
  const token = cookies().get("token");

  if (token) {
    redirect("/dashboard/learn");
  }
  return <SignupComp />;
}
