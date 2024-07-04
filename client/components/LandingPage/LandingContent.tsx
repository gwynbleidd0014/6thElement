import Image from "next/image";
import Link from "next/link";
import landingImage from '../../public/assets/images/landing-image1.jpg'

const LandingContent = () => {
  return (
    <>
    <div className="relative">
      <Image src={landingImage} alt="Landing image" className="h-[100vh] object-center"/>
    </div>
      <main className="p-8 absolute w-[500px] top-1/3 left-[200px]">
        <section className="flex justify-center flex-col">
          <div className="flex flex-col gap-4">
            <h1 className="text-[32px] font-bold">
              The free, fun, and effective way to learn a finances!
            </h1>
            <Link
              href="/auth/login"
              className="bg-[#1CB0F6] hover:bg-[#77ccf3] duration-300 text-white p-2 py-3 rounded-xl w-[330px] items-center text-center uppercase font-bold tracking-widest shadow-[0_6px_0] shadow-[#378CE7]"
            >
              Get Started
            </Link>
          </div>
        </section>
      </main>
    </>
  );
};

export default LandingContent;
