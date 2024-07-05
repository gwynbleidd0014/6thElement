import LandingContent from "@/components/LandingPage/LandingContent";
import { cookies } from "next/headers";
import { redirect } from "next/navigation";

export default function Home() {
const token = cookies().get("token");

  if (token) {
    redirect("/dashboard/learn");
  }
  return <LandingContent />;
}
