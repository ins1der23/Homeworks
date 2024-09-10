namespace HumanFriends.Model;
interface IPet : IBaseAnimal
{
    void ChangeFeature(int featureId) => FeatureId = featureId;
    
}