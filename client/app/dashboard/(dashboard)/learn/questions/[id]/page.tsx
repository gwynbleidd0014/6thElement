import Questions from "@/components/dashboard/Learn/Questions";

interface ModuleRoad {
  params: {
    id: number;
  };
}

export default function ModuleRoad({ params: { id } }: ModuleRoad) {
  return <Questions />;
}
