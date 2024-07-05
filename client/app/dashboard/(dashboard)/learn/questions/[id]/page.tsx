import Questions from "@/components/dashboard/Learn/Questions";
import { getQuestions } from "@/lib/actions";

interface ModuleRoad {
  params: {
    id: number;
  };
}

export default async function ModuleRoad({ params: { id } }: ModuleRoad) {
  const questions = await getQuestions(id);

  return (
    <Questions questions={questions.questions} modulId={questions.moduleId} />
  );
}
