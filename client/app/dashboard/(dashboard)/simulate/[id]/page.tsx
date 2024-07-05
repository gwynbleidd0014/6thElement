import SimulateDetailsComp from "@/components/dashboard/Simulate/SimulateDetailsComp";

interface Simulate {
  params: {
    id: number;
  };
}

export default async function SimulateDetails({ params: { id } }: Simulate) {
  return <SimulateDetailsComp />;
}
