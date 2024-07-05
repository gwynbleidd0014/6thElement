import ModuleRoadComp from "@/components/dashboard/Learn/ModuleRoadComp";
import { getChaptersById } from "@/lib/actions";

interface ModuleRoad {
  params: {
    id: number;
  };
}

export default async function ModuleRoad({ params: { id } }: ModuleRoad) {
  const chapters = await getChaptersById(id);

  return <ModuleRoadComp chapters={chapters.chapters} title={chapters.name} />;
}
