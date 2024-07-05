import LearnComp from "@/components/dashboard/Learn/LearnComp";
import { getModules } from "@/lib/actions";

export default async function Learn() {
  const moduleData = await getModules();

  return <LearnComp moduleData={moduleData} />;
}
