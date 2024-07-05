export interface ModuleData {
  chapters: null;
  id: number;
  imagePath: string;
  name: string;
  type: string;
}

export interface Chapters {
  id: number;
  order: number;
  moduleId: number;
  questions: null;
}

export interface Answers {
  id: number;
  description: string;
}

export interface QuestionsType {
  description: string;
  imagePath: string;
  answers: Answers[];
}
