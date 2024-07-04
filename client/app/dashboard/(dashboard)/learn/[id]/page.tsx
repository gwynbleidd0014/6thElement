import ModuleRoadComp from "@/components/dashboard/Learn/ModuleRoadComp";

interface ModuleRoad {
  params: {
    id: number;
  };
}

export default function ModuleRoad({ params: { id } }: ModuleRoad) {
  return <ModuleRoadComp />;
}
